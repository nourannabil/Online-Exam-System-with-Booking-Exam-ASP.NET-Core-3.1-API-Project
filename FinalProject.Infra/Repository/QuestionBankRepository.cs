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
    public class QuestionBankRepository : IGenericRepository<QuestionBank2> , IQuestionBankRepository
    {
        private readonly IDbContext _dbContext;

        public QuestionBankRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(QuestionBank2 questionBank)
        {
            var p = new DynamicParameters();
            p.Add("QUESTION_T", questionBank.Questiontitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CORRECT_AN", questionBank.Correctanswer, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O1", questionBank.Answeroption1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O2", questionBank.Answeroption2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O3", questionBank.Answeroption3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O4", questionBank.Answeroption4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QUESTION_M", questionBank.Questionmark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CID", questionBank.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("QUESTION_BANK2_PACKAGE.CREATE_QUESTION_BANK2", p, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("QUESTION_BANK2_PACKAGE.DELETE_QUESTION_BANK2_ByID", p, commandType: CommandType.StoredProcedure);
        }


        public QuestionBank2 GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<QuestionBank2> result = _dbContext.Connection.Query<QuestionBank2>("QUESTION_BANK2_PACKAGE.GET_QUESTION_BANK2_BYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<QuestionBank2> GetAll()
        {
            IEnumerable< QuestionBank2 > result = _dbContext.Connection.Query< QuestionBank2> ("QUESTION_BANK2_PACKAGE.GETALL_QUESTION_BANK2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void Update(QuestionBank2 questionBank)
        {
            var p = new DynamicParameters();
            p.Add("ID", questionBank.Questionid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QUESTION_T", questionBank.Questiontitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CORRECT_AN", questionBank.Correctanswer, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O1", questionBank.Answeroption1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O2", questionBank.Answeroption2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O3", questionBank.Answeroption3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ANSWER_O4", questionBank.Answeroption4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("QUESTION_M", questionBank.Questionmark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CID", questionBank.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Execute("QUESTION_BANK2_PACKAGE.UPDATE_QUESTION_BANK2", p, commandType: CommandType.StoredProcedure);
        }

        public List<QuestionBank2> GetRandomQuestionsByCourseId(int courseId)
        {
            var p = new DynamicParameters();
            p.Add("COURSE_NUM", courseId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<QuestionBank2> result = _dbContext.Connection.Query<QuestionBank2>("QUESTION_BANK2_PACKAGE.GET_RANDOM_QUESTIONS_BYCOURSEID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
