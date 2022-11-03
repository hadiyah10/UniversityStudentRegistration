namespace RepositoryClassLibrary.SQLQueries
{
    public class SqlQueries
    {
        public const string CreateResult = @"Insert into Results ([SubjectId], [Grade], [StudentId]) Values (@SubjectId, @Grade, @StudentId)";
        public const string GetResultsQuery = @"select StudentId, ResultId, s.SubjectId, SubjectName, Grade
                                              from Results r
                                              inner join Subjects s on r.SubjectId=s.SubjectId";
        public const string CreateStudentQuery = @"Insert into Students
        ([NationalId],[FirstName],[Surname], [PhoneNumber], [DateOfBirth], [GuardianName], [Address], [StudentId], [Status])
        values (@NationalId, @FirstName, @Surname, @PhoneNumber, @DateOfBirth, @GuardianName, @Address, @StudentId , @Status)";
        public const string GetStudentQuery = @"Select [StudentId], [NationalId],[FirstName],[Surname], [PhoneNumber], [DateOfBirth], [GuardianName], [Address], [Status] from Students";
        public const string GetStudentSummary = @"Select [FirstName], [Surname], [Status] from Students";
        public const string GetUserQuery = @"Select [UserId], [Email]";
        public const string GetResultsByStudentId = @"select ResultId, s.SubjectId, SubjectName, Grade
                                        from Results r
                                        inner join Subjects s on r.SubjectId=s.SubjectId
                                        where StudentId=@StudentId";
        public const string GetAllRoles = @"SELECT RoleId FROM UserRoles WHERE UserId=@UserId";

        public string GetCreateResultQuery() {
            return CreateResult;
        }

        public string GetAllResultsQuery()
        {
            return GetResultsQuery;
        }

        public string GetStudentSummaryQuery()
        {
            return GetStudentSummary;
        }
        public string CreateStudentsQuery()
        {
            return CreateStudentQuery;
        }
        public string GetAllStudentsQuery()
        {
            return GetStudentQuery;
        }
    }
}
