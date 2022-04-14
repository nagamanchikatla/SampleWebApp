using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Data
{
    public class RetroRepository : IRetroRepository
    {
        private readonly RetroDBContext _context;

        public RetroRepository(RetroDBContext context)
        {
            _context = context;
        }
        public Retro AddRetro(Retro retro)
        {
            _context.Retros.Add(retro);
            _context.SaveChanges();
            return retro;

        }

        Feedback IRetroRepository.AddFeedBack(Feedback feedback)
        {
            Retro retro = _context.Retros.FirstOrDefault(r => r.RName == feedback.RName);
            if (retro == null) return null;
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
            return feedback;
        }

        List<Retro> IRetroRepository.GetRetro()
        {
            List<Retro> sortedRetroList = new List<Retro>();

            var retroList = _context.Retros.ToList();
            var feedbackList = _context.Feedbacks.ToList();
            foreach(var retro in retroList)
            {
                List<Feedback> feedbacks = new List<Feedback>();
                foreach(var feedback in feedbackList)
                {
                    if(retro.RName == feedback.RName)
                    {
                        feedbacks.Add(feedback);
                    }
                }
                retro.Fdback = feedbacks;
                sortedRetroList.Add(retro);
            }
            return sortedRetroList;
        }

        List<Retro> IRetroRepository.GetRetroByDate(string date)
        {
            List<Retro> sortedRetroList = new List<Retro>();
            var retroList = _context.Retros.ToList();
            var feedbackList = _context.Feedbacks.ToList();

            DateTime convertedDate = DateTime.Parse(date);

            foreach(var retro in retroList)
            {
                DateTime retroDate = DateTime.Parse(retro.Date);
                if (retroDate == convertedDate)
                {
                    List<Feedback> feedbacks = new List<Feedback>();
                    foreach (var feedback in feedbackList)
                    {
                        if (retro.RName == feedback.RName)
                        {
                            feedbacks.Add(feedback);
                        }
                    }
                    retro.Fdback = feedbacks;
                    sortedRetroList.Add(retro);
                }
            }
            return sortedRetroList;
        }

        List<string> IRetroRepository.GetRetroNames()
        {
            List<string> retroNames = new List<string>();
            var retroList = _context.Retros.ToList();

            foreach(var retro in retroList)
            {
                retroNames.Add(retro.RName);
            }
            return retroNames;

        }

        bool IRetroRepository.IsRetroNameExist(string rName)
        {
           return  _context.Retros.FirstOrDefault(r => r.RName == rName) != null;
        }
    }
}
