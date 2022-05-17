using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EmployeePayrollMultiThreading
{
    public class EmployeePayrollOperations
    {
        public List<EmployeeDetails> employeePayrollDetailsList = new List<EmployeeDetails>();
       
        /// <summary>
        /// UC1-Employee Detail Add
        /// </summary>
        /// <param name="employeePayrollDetailsList"></param>
        public void AddEmployeeToPayroll(List<EmployeeDetails> employeePayrollDetailsList)
        {
            employeePayrollDetailsList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added: " + employeeData.EmployeeName);
            });
            Console.WriteLine("No. of employees: " + this.employeePayrollDetailsList.Count);
            Thread thr = Thread.CurrentThread;
            Console.WriteLine("Thread: " + thr.ManagedThreadId);
        }

        public void AddEmployeePayroll(EmployeeDetails emp)
        {
            employeePayrollDetailsList.Add(emp);
        }
        public int EmployeeCount()
        {
            return this.employeePayrollDetailsList.Count;
        }

        /// <summary>
        /// UC 2 - Employee Details with Multi Threads
        /// </summary>
        /// <param name="employeePayrollDetailsList"></param>
        public void AddEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDetailsList)
        {
            employeePayrollDetailsList.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added: " + employeeData.EmployeeName);
                });
                thread.Start();
                Console.WriteLine("Thread:" + thread.ManagedThreadId);
            });
        }   
    }
}
