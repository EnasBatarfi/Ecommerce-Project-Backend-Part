using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Backend.Data;
using Backend.Dtos;
using Backend.EmailSetup;
using Backend.Helpers;
using Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services;

public class AdminService
{
    private readonly AppDbContext _dbContext;
    private readonly IPasswordHasher<Admin> _passwordHasher;
    private readonly IEmailSender _emailSender;
    private readonly IMapper _mapper;

    public AdminService(AppDbContext dbContext, IPasswordHasher<Admin> passwordHasher, IEmailSender emailSender, IMapper mapper)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _emailSender = emailSender;
        _mapper = mapper;
    }


    public async Task<IEnumerable<AdminDto>> GetAllAdminsService(int currentPage, int pageSize)
    {
        var admins = await _dbContext.Admins
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var adminDtos = _mapper.Map<List<Admin>, List<AdminDto>>(admins);
        return adminDtos;
    }


    public async Task<AdminDto?> GetAdminById(Guid adminId)
    {
        var admin = await _dbContext.Admins.FindAsync(adminId);
        var adminDto = _mapper.Map<AdminDto>(admin);
        return adminDto;
    }


    public async Task<Admin?> CreateAdminService(Admin newAdmin)
    {
        bool userExist = await IsEmailExists(newAdmin.Email);
        if (userExist)
        {
            return null;
        }

        newAdmin.AdminId = Guid.NewGuid();
        newAdmin.Email = newAdmin.Email.ToLower();
        newAdmin.CreatedAt = DateTime.UtcNow;
        newAdmin.Password = _passwordHasher.HashPassword(newAdmin, newAdmin.Password);
        _dbContext.Admins.Add(newAdmin);
        await _dbContext.SaveChangesAsync();
        return newAdmin;
    }


    public async Task<LoginUserDto?> LoginAdminService(LoginUserDto loginUserDto)
    {
        var admin = await _dbContext.Admins.SingleOrDefaultAsync(a => a.Email == loginUserDto.Email.ToLower());
        if (admin == null)
        {
            return null;
        }

        var result = _passwordHasher.VerifyHashedPassword(admin, admin.Password, loginUserDto.Password);
        loginUserDto.UserId = admin.AdminId;
        loginUserDto.IsAdmin = true;
        return result == PasswordVerificationResult.Success ? loginUserDto : null;
    }


    public async Task<Admin?> UpdateAdminService(Guid adminId, AdminDto updateAdmin)
    {
        var existingAdmin = await _dbContext.Admins.FindAsync(adminId);
        if (existingAdmin != null)
        {
            existingAdmin.FirstName = updateAdmin.FirstName.IsNullOrEmpty() ? existingAdmin.FirstName : updateAdmin.FirstName;
            existingAdmin.LastName = updateAdmin.LastName.IsNullOrEmpty() ? existingAdmin.LastName : updateAdmin.LastName;
            existingAdmin.Email = updateAdmin.Email.IsNullOrEmpty() ? existingAdmin.Email : updateAdmin.Email.ToLower();
            existingAdmin.Mobile = updateAdmin.Mobile.IsNullOrEmpty() ? existingAdmin.Mobile : updateAdmin.Mobile;
            existingAdmin.Image = updateAdmin.Image.IsNullOrEmpty() ? existingAdmin.Image : updateAdmin.Image;
            await _dbContext.SaveChangesAsync();
        }

        return existingAdmin;
    }


    public async Task<bool> DeleteAdminService(Guid adminId)
    {
        var adminToRemove = await _dbContext.Admins.FindAsync(adminId);
        if (adminToRemove != null)
        {
            _dbContext.Admins.Remove(adminToRemove);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }


    public async Task<bool> ForgotPasswordService(string email)
    {
        var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.Email == email);
        if (admin == null)
        {
            return false;
        }

        var resetToken = Guid.NewGuid();
        admin.ResetToken = resetToken;
        admin.ResetTokenExpiration = DateTime.UtcNow.AddHours(1);
        // bc we still not have real host so i will just send a token so we can test it using swagger in the production adjust this 2 lines
        // string resetLink = $"http://localhost:5125/api/admins/reset-password?email={email}&token={resetToken}";
        await _emailSender.SendEmailAsync(email, "Password Reset", $"Dear {admin.FirstName},\nThis is your token {resetToken} to reset your password");
        await _dbContext.SaveChangesAsync();
        return true;
    }


    public async Task<bool> ResetPasswordService(ResetPasswordDto resetPasswordDto)
    {
        var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.Email == resetPasswordDto.Email);
        if (admin == null || admin.ResetToken != resetPasswordDto.Token || admin.ResetTokenExpiration < DateTime.UtcNow)
        {
            return false;
        }

        admin.Password = _passwordHasher.HashPassword(admin, resetPasswordDto.NewPassword);
        admin.ResetToken = null;
        admin.ResetTokenExpiration = null;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsEmailExists(string email)
    {
        return await _dbContext.Admins.AnyAsync(a => a.Email == email.ToLower()) || await _dbContext.Customers.AnyAsync(c => c.Email == email.ToLower());
    }

    public async Task<int> GetTotalAdminCount()
    {
        return await _dbContext.Admins.CountAsync();
    }
}