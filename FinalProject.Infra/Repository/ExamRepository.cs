using Dapper;
using FinalProject.Core.Common;
using FinalProject.Core.Data;
using FinalProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FinalProject.Infra.Repository
{
    public class ExamRepository : IGenericRepository<Exam2>,IExamRepository
    {
        private readonly IDbContext _dbContext;

        public ExamRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Exam2 exam)
        {
            var p = new DynamicParameters();
            p.Add("ENAME", exam.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESCRIPT", exam.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEP", exam.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EXAM_DU", exam.Examduration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EXAM_PR", exam.Examprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PASS_MA", exam.Passmark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CID", exam.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NUMOFQUS", exam.NUMOFQUESTIONS, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EXAM2_PACKAGE.CREATE_EXAM2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EXAM2_PACKAGE.DELETE_EXAM2_ByID", p, commandType: CommandType.StoredProcedure);
        }

        public List<Exam2> GetAll()
        {
            IEnumerable<Exam2> result = _dbContext.Connection.Query<Exam2>("EXAM2_PACKAGE.GETALL_EXAM2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Exam2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Exam2> result = _dbContext.Connection.Query<Exam2>("EXAM2_PACKAGE.GET_EXAM2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void Update(Exam2 exam)
        {
            var p = new DynamicParameters();
            p.Add("ID", exam.Examid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ENAME", exam.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DESCRIPT", exam.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEP", exam.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("EXAM_DU", exam.Examduration, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EXAM_PR", exam.Examprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PASS_MA", exam.Passmark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CID", exam.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NUMOFQUS", exam.NUMOFQUESTIONS, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("EXAM2_PACKAGE.UPDATE_EXAM2", p, commandType: CommandType.StoredProcedure);
        }

        public List<Exam2> SearchByExamName(string name)
        {
            var p = new DynamicParameters();
            p.Add("ENAME", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Exam2> result = _dbContext.Connection.Query<Exam2>("EXAM2_PACKAGE.SEARCH_BY_EXAM_NAME", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Exam2> GetExamFromCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("COURSE_NUM", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Exam2> result = _dbContext.Connection.Query<Exam2>("EXAM2_PACKAGE.GetALL_EXAM_FROM_EACH_COURSE", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<DateTime?> GetAllAvaliableTimeForEeachExam(int id)
        {
            var p = new DynamicParameters();
            p.Add("EXAM_NUM", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<AvaliableTable2> result = _dbContext.Connection.Query<AvaliableTable2>("EXAM2_PACKAGE.GetALL_AVALIABLE_TIME_FOR_EACH_EXAM", p, commandType: CommandType.StoredProcedure);
            var finalResult = result.Where<AvaliableTable2>(x => x.Statusid == 3).Select(x => x.Examstartdate).ToList();
            return finalResult.ToList();
        }
    }
}
