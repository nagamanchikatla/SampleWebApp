using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Data
{
    public interface IRetroRepository
    {
        Retro AddRetro(Retro retro);
        Boolean IsRetroNameExist(string rName);
        List<Retro> GetRetro();
        List<Retro> GetRetroByDate(string date);
        Feedback AddFeedBack(Feedback feedback);
    }
}
