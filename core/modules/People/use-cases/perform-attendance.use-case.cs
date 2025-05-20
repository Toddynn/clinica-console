using System;
using Core.Modules.People.Models.Entities;

namespace Core.Modules.People.UseCases
{
    public class PerformAttendanceUseCase
    {
        private readonly Employee _employee;

        public PerformAttendanceUseCase(Employee employee)
        {
            _employee = employee;
        }

        public void Execute()
        {
            _employee.PerformAttendance();
        }
    }
}
