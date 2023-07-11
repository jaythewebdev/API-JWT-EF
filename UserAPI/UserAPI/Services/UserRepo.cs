using Microsoft.Data.SqlClient;
using System.Diagnostics;
using UserAPI.Exceptions.CustomExceptions;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserRepo : IUser<int,User>
    {
        private readonly JWTUserContext _context;

        public UserRepo(JWTUserContext context)
        {
            _context = context;
        }

        public User Add(User item)
        {
            try
            {
                var user = _context.Users;
                var myUser=user.SingleOrDefault(u => u.Username== item.Username);
                if (myUser!=null)
                {
                    return null;
                }
                else
                {
                    _context.Users.Add(item);
                    _context.SaveChanges();
                    return item;
                }
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public User Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == id);
                if (user!=null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return user;
                }
                return null;
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public User Get(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == id);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public ICollection<User> GetAll()
        {
            try
            {
                var user = _context.Users.ToList();
                if (user != null)
                    return user;
                return null;
            }
            catch(NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch(ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public User Update(User item)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == item.Username);
                if (user != null)
                {
                    user.Password = item.Password;
                    user.Name = item.Name;
                    user.Email = item.Email;
                    user.PhoneNumber = item.PhoneNumber;
                    user.Age = item.Age;
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }
    }
}
