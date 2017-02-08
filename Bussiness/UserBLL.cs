using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class UserBLL : IBussiness<User>
    {
        UnitOfWork _uow;
        public UserBLL()
        {
            _uow = new UnitOfWork();
        }

        public User Login(string eMail, string password)
        {
            return _uow.UserRepository.GetAll().FirstOrDefault(x => x.EMail==eMail && x.Password==password);
        }

        public bool Add(User item)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _uow.UserRepository.Get(id);
        }

        public bool UpdatePassword(int userID, string oldPassword, string newPassword, string newPasswordConfirm, out string message)
        {

            User user = _uow.UserRepository.Get(userID);
            if (user.Password!=oldPassword)
            {
                message = "Kayıtlı parolanızı yanlış girdiniz";
                return false;
            }
            else if (newPassword!=newPasswordConfirm)
            {
                message = "Girilen yeni parolalar eşleşmiyor";
                return false;
            }
            else
            {
                user.Password = newPassword;
                _uow.UserRepository.Update(user);
                if (_uow.ApplyChanges())
                {
                    message = "Parolanız başarıyla güncellenmiştir";
                    return true;
                }
                else
                {
                    message = "Güncelleme işleminde problem yaşandı, daha sonra tekrar deneyiniz";
                    return false;
                }
            }
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Add(User user, string mailConfirm, string passwordConfirm, out string message)
        {
            message = "";
            if (user.EMail!=mailConfirm)
            {
                message = "Mail Adresleri Eşleşmiyor";
                return false;
            }
            else if (user.Password!=passwordConfirm)
            {
                message = "Parolalar Eşleşmiyor";
                return false;
            }
            else
            {
                _uow.UserRepository.Add(user);
                if (_uow.ApplyChanges())
                {
                    message = "Kayıt İşlemi Başarılı";
                    return true;
                }
                else
                {
                    message = "Kayıt İşlemi Yapılamadı";
                    return false;
                }
            }
        }

        public bool Remove(User item)
        {
            throw new NotImplementedException();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
