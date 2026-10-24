


namespace KarataClub.Application.Features.BeltTests.Queries.GetBeltTests
{
    internal class BeltTestsHandler(
        IAppDbContext context,ILogger<BeltTestsHandler> logger
        ) : IRequestHandler<BeltTestsQuery, Result<PaginatedList<BeltTestDto>>>
    {
        public async Task<Result<PaginatedList<BeltTestDto>>> Handle(BeltTestsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<BeltTest> query = context.BeltTests
           .AsNoTracking()
            .Include(bt => bt.Member)
              .ThenInclude(m => m.Person)
            .Include(bt => bt.Member)
              .ThenInclude(bt => bt.LastBeltRank)
            .Include(bt => bt.Instructor)
              .ThenInclude(i => i.Person)
            .Include(bt => bt.BeltRank);
            query = ApplyFilter(query, request.RankName,request.MemberName,request.InstructorName, request.FeesFrom, request.FeesTo);
            query = ApplySorting(query, request.SortColumn, request.SortDirection);
            Result<PaginatedList<BeltTestDto>> BeltRank = await PaginatedList<BeltTestDto>.Create(
                 query.ToDto(), request.PageNumber, request.PageSize
                 );

            return BeltRank;
        }

        private IQueryable<BeltTest> ApplyFilter(IQueryable<BeltTest> query, string? RankName,
            string? MemberName,string? InstructorName,
             decimal? feesFrom, decimal? feesTo)
        {
            if (!string.IsNullOrWhiteSpace(RankName))
                query = query.Where(q => q.BeltRank.RankName.Contains(RankName));
            if (!string.IsNullOrWhiteSpace(MemberName))
                query = query.Where(q => q.Member.Person.Name.Contains(MemberName));
            if (!string.IsNullOrWhiteSpace(InstructorName))
                query = query.Where(q => q.Instructor.Person.Name.Contains(InstructorName));
            if (feesFrom.HasValue)
            {
                query = query.Where(q => q.BeltRank.TestFees >= feesFrom.Value);
            }
            if (feesTo.HasValue)
            {
                query = query.Where(q => q.BeltRank.TestFees <= feesTo.Value);
            }
            return query;
        }

        private IQueryable<BeltTest> ApplySorting(IQueryable<BeltTest> query, string sortColumn, string sortDirection)
        {
            bool desc = sortDirection.Equals("Desc", StringComparison.CurrentCultureIgnoreCase);
            query = sortColumn switch
            {
                "RankName" => desc ? query.OrderByDescending(q => q.BeltRank.RankName) :
                query.OrderBy(q => q.BeltRank.RankName),
                "MemberName" => desc ? query.OrderByDescending(q => q.Member.Person.Name) :
                query.OrderBy(q => q.Member.Person.Name),
                "InstructorName" => desc ? query.OrderByDescending(q => q.Instructor.Person.Name) :
                query.OrderBy(q => q.Instructor.Person.Name),
                "Fees" => desc ? query.OrderByDescending(q => q.BeltRank.TestFees) : query.OrderBy(q => q.BeltRank.TestFees),
                _ => desc ? query.OrderByDescending(q => q.BeltRank.RankName) :
                query.OrderBy(q => q.BeltRank.RankName)
            };
            return query;
        }
    }
}
