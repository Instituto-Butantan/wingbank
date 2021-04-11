using System.Data.SqlClient;
using Dapper;

namespace MosquitoLab.Domain.Individuals.Filters
{
    public class WingFilterSql : WingFilter
    {
        public SqlParameter TextParam { get; private set; }
        public SqlParameter SpecificLocalityParam { get; private set; }
        public SqlParameter LocalityParam { get; private set; }
        public SqlParameter CityParam { get; private set; }
        public SqlParameter StateParam { get; private set; }
        public SqlParameter CountryParam { get; private set; }
        public SqlParameter DateParam { get; private set; }
        public SqlParameter LatitudeParam { get; private set; }
        public SqlParameter LongitudeParam { get; private set; }
        public SqlParameter GenderParam { get; private set; }
        public SqlParameter WingSideParam { get; private set; }
        public SqlParameter FamilyNameParam { get; private set; }
        public SqlParameter GenusNameParam { get; private set; }
        public SqlParameter SpecieNameParam { get; private set; }
        public SqlParameter InstitutionNameParam { get; private set; }
        public SqlParameter MosquitoLabCodeParam { get; private set; }
        public SqlParameter LeczParam { get; private set; }

        public DynamicParameters Do()
        {
            TextParam = new SqlParameter("@Text", Text);
            SpecificLocalityParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            LocalityParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            CityParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            StateParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            CountryParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            DateParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            LatitudeParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            LongitudeParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            GenderParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            WingSideParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            FamilyNameParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            GenusNameParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            SpecieNameParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            InstitutionNameParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            MosquitoLabCodeParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            LeczParam = new SqlParameter("@SpecificLocality", SpecificLocality);
            var param = new DynamicParameters(new
            {
                Text = TextParam,
                SpecificLocality = SpecificLocalityParam,
                Locality = LocalityParam,
                City = CityParam,
                State = StateParam,
                Country = CountryParam,
                Date = DateParam,
                Latitude = LatitudeParam,
                Longitude = LongitudeParam,
                Gender = GenderParam,
                WingSide = WingSideParam,
                FamilyName = FamilyNameParam,
                GenusName = GenusNameParam,
                SpecieName = SpecieNameParam,
                InstitutionName = InstitutionNameParam,
                MosquitoLabCode = MosquitoLabCodeParam,
                Lecz = LeczParam
            });
            return param;
        }
    }
}
