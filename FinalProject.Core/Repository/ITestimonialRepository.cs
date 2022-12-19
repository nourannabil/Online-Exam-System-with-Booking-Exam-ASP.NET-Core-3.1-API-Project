using FinalProject.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Repository
{
    public interface ITestimonialRepository
    {
        void AcceptTestimonial(int testId);
        void RejectTestimonial(int testId);
        List<TestimonialTable2> GetAcceptTestimonial();
    }
}
