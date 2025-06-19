using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastracture.Persistence.Repositories.Base;
using Microsoft.VisualBasic;

namespace Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository
{
    public class NoorEmployeeRepository : DapperGenericRepositoryBase<NoorEmployee>, INoorEmployeeRepository
    {
        
        public NoorEmployeeRepository(string connectionString) :base(connectionString)
        {
            
        }
        

        public Task AddAsync(NoorEmployee entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoorEmployee>> GetAllAsync()
        {
            //string query = "SELECT COMPANY_ID, EMP_NO, FNAME, LNAME, PICTURE_ID, DATE_OF_BIRTH, SEX, BLOOD_TYPE FROM company_person_all WHERE company_id IN ('NE', 'KL', 'NT', 'KS', 'KK', 'GK') AND EMPLOYEE_STATUS = '*' AND EMP_NO <> 'SYS'";
            /*
            string query = """
                SELECT 
                cpa.COMPANY_ID, 
                cpa.EMP_NO, 
                cpa.FNAME, 
                cpa.LNAME, 
                cpa.PICTURE_ID, 
                TO_CHAR(cpa.DATE_OF_BIRTH,'yyyy.MM.dd') as DATE_OF_BIRTH, 
                cpa.SEX, 
                cpa.BLOOD_TYPE,
                TO_CHAR(et.date_of_employment,'yyyy.MM.dd') as date_of_employment,
                TO_CHAR(et.date_of_leaving,'yyyy.MM.dd') as date_of_leaving
                FROM company_person_all cpa, emp_employed_time_row et
                WHERE cpa.company_id = et.company_id
                and cpa.emp_no = et.emp_no
                and cpa.company_id IN ('NE', 'KL', 'NT', 'KS', 'KK', 'GK') 
                AND cpa.EMPLOYEE_STATUS = '*' AND cpa.EMP_NO <> 'SYS'
                and et.date_of_leaving >= TO_CHAR(SYSDATE,'dd.MM.yyyy')
            """;
            */

            string query = """
                select 
                COMPANY_ID,
                EMP_NO,
                FNAME,
                LNAME,
                PICTURE_ID,
                DATE_OF_BIRTH,
                SEX,
                BLOOD_TYPE,
                EMPLOYEE_STATUS,
                DATE_OF_EMPLOYMENT,
                CASE
                WHEN DATE_OF_LEAVING > TO_CHAR(SYSDATE,'yyyy.MM.dd')
                    THEN null
                    ELSE DATE_OF_LEAVING
                END AS DATE_OF_LEAVING
                from vw_meyer_set_sicil
            """;

            var sql = $"{query}";
            return GetAllAsync(sql);
        }

        public Task<NoorEmployee> GetByIdAsync(Expression<Func<NoorEmployee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}