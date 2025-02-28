using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UserRegisteryNET.Helpers;

namespace UserRegisteryNET.Data
{
    internal static  class UsersRepository
    {

        internal async static Task<List<User>> GetUsersAsync()
        {
            using (var db = new AppDBContext()) // Garbage collection için using kullandım
            {
                return await db.Users.ToListAsync();
            }
        }

        internal async static Task<User> GetUserByIdAsync(int userId)
        {
            using (var db = new AppDBContext())
            {
                // Handle null return
                return await db.Users.FirstOrDefaultAsync(user => user.UserId == userId);
            }
        }

        internal async static Task<User> GetUserByTCKNAsync(string tckn)
        {
            using (var db = new AppDBContext())
            {
                // Normalize the input TCKN by trimming any whitespace
                tckn = tckn?.Trim();

                // Validate TCKN format before querying
                if (!TCKNValidator.IsValidTCKN(tckn))
                {
                    return null;
                }

                // Handle null return
                return await db.Users.FirstOrDefaultAsync(user => user.TCKN == tckn);
            }
        }

        internal async static Task<bool> CreateUserAsync(User userToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    if (!TCKNValidator.IsValidTCKN(userToCreate.TCKN))
                    {
                        Console.WriteLine("Error: Invalid TCKN format.");
                        return false;
                    }

                    await db.Users.AddAsync(userToCreate);

                    return await db.SaveChangesAsync() >= 1; // 1'den büyükse true döner ancak hatalı olabilir (aynı anda birden fazla işlem olursa)

                }
                catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    // TCKN unique olmalı, olmadığında gelen erroru handle edelim
                    Console.WriteLine("Error: A user with this TCKN already exists.");
                    return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateUserAsync(User userToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Users.Update(userToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteUserAsync(int userId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    User userToDelete = await GetUserByIdAsync(userId);
                    db.Remove(userToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }

        internal async static Task<bool> DeleteUserByTCKNAsync(string tckn)
        {
            using (var db = new AppDBContext())
            {

                try
                {
                    User userToDelete = await GetUserByTCKNAsync(tckn);
                    db.Remove(userToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
