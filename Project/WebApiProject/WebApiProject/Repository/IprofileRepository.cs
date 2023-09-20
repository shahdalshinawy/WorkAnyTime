using WebApiProject.DTO;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
    public interface IprofileRepository
    {
        void New(ProfileDTO Profile);
        void New(ProfileDataDTO ProfiledataDTo);
        Profile GetById(string id);
        void Edit(string id, ProfileDataDTO ProfileDataDTo);
        void Delete(string id);
        void EditImage(string image, string id);
        void EditProtofilo(ProtofiloDto protofilo, string id);
        //Profile GetAll();


    }
}
