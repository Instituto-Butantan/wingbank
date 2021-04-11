using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MosquitoLab.Domain.Individuals.Dtos;
using MosquitoLab.Domain.Individuals.Entities;
using MosquitoLab.Domain.Individuals.Filters;
using MosquitoLab.Domain.Individuals.Repositories;
using MosquitoLab.Domain.Persistence.Context;
using MosquitoLab.Infra.Common.Repositories;

namespace MosquitoLab.Infra.Publications.Repositories
{
    public class WingImageRepository : Repository<WingImage>, IWingImageRepository
    {
        public WingImageRepository(IDbContext context) : base(context)
        {
        }

        public IList<WingResultDto> Find(WingFilter filter)
        {
            var param = filter;

            using (Connection)
            {
                var query = new StringBuilder();
                query.Append(QueryBase);
                query.Append(@"
	                        (@Text is not null 
		                        and (
				                        (
					                        ((@Text like '%right%' or @Text like '%direita%' or @Text = 'r') and wi.WingSide = 'r')
					                        or ((@Text like '%left%' or @Text like '%left%' or @Text = 'l') and wi.WingSide = 'l')
				                        )
				                        or (
					                        ((@Text like '%macho%' or @Text like '%male%' or @Text = 'm') and i.Gender = 'm')
					                        or ((@Text like '%femea%' or @Text like '%femêa%' or @Text like '%female%' or @Text = 'f') and wi.WingSide = 'f')
				                        )
				                        or (ic.CollectionCode  like '%' + @Text + '%')
				                        or (ic.LabCode like '%' + @Text + '%')
				                        or (ic.TempLabCode like '%' + @Text + '%')
				                        or (
					                        l.Country like '%' + @Text  + '%'
					                        or l.CountryCode like '%' + @Text  + '%'
				                        )
				                        or (
					                        l.StateOrProvince like '%' + @Text  + '%'
					                        or l.StateOrProvinceCode like '%' + @Text  + '%'
				                        )
				                        or (
					                        l.City like '%' + @Text  + '%'
					                        or l.CityCode like '%' + @Text  + '%'
				                        )
				                        or (l.Latitude = @Text)
				                        or (l.Longitude = @Text)
				                        or (
					                        l.StateOrProvince like '%' + @Text  + '%'
					                        or l.StateOrProvinceCode like '%' + @Text  + '%'
					                        or l.City like '%' + @Text  + '%'
					                        or l.CityCode like '%' + @Text  + '%'
					                        or l.Country like '%' + @Text  + '%'
					                        or l.CountryCode like '%' + @Text  + '%'
					                        or l.Neighborhood like '%' + @Text  + '%'
				                        )
				                        or (
					                        fs.SpecificLocalityInEnglish like '%' + @Text  + '%'
					                        or fs.SpecificLocalityOriginalLanguage like '%' + @Text  + '%'
				                        )
				                        or ( 
					                        f.FamilyName like '%' + @Text  + '%'
					                        or sf.SubfamilyName like '%' + @Text  + '%'
				                        )
				                        or (
					                        g.GenericName like '%' + @Text  + '%'
					                        or sg.SubgenericName like '%' + @Text  + '%'
				                        )
				                        or (
					                        s.SpecificEpithet like '%' + @Text  + '%'
					                        or ss.SubspeciesName like '%' + @Text  + '%'
				                        )
				                        or (
					                        itt.NameInEnglish = '%' + @Text + '%'
					                        or itt.NameOriginalLanguage like '%' + @Text + '%'
					                        or itt.Abbreviation like '%' + @Text + '%'
				                        )
				                        or (
					                        (
						                        convert(varchar, fs.[DateTime], 103) = @Text
						                        or convert(varchar, fs.[DateTime], 111) = @Text
						                        or (CAST(MONTH(fs.[DateTime]) as varchar)  + '/' + CAST(YEAR(fs.[DateTime]) as varchar) = @Text)
						                        or (CAST(YEAR(fs.[DateTime]) as varchar)  + '/' + CAST(MONTH(fs.[DateTime]) as varchar) = @Text)
						                        or (CAST(YEAR(fs.[DateTime]) as varchar) = @Text)
					                        )
					                        or (
						                        convert(varchar, o.DonationDatetime, 103) = @Text
						                        or convert(varchar, o.DonationDatetime, 111) = @Text
						                        or (CAST(MONTH(o.DonationDatetime) as varchar)  + '/' + CAST(YEAR(o.DonationDatetime) as varchar) = @Text)
						                        or (CAST(YEAR(o.DonationDatetime) as varchar)  + '/' + CAST(MONTH(o.DonationDatetime) as varchar) = @Text)
						                        or (CAST(YEAR(o.DonationDatetime) as varchar) = @Text)
					                        )
				                        )
		                        )
	                        )
	                        or(
		                        @Text is null 
		                        and( 
				                        (@WingSide is null or wi.WingSide = @WingSide)
			                        and (@Gender is null or i.Gender = @Gender)
			                        and (@Lecz is null or  ic.CollectionCode  like '%' + @Lecz + '%')
			                        and (@MosquitoLabCode is null or ic.LabCode like '%' + @MosquitoLabCode + '%')
			                        and (@Date is null 
				                        or (
					                        (
						                        CAST(fs.[DateTime] as smalldatetime) = CAST( @Date as smalldatetime)
						                        or (MONTH(fs.[DateTime]) = MONTH(@Date) and  YEAR(fs.[DateTime]) = YEAR(@Date))
						                        or (YEAR(fs.[DateTime]) = YEAR(@Date))
					                        )
					                        or (
						                        CAST(o.DonationDatetime as smalldatetime) = CAST( @Date as smalldatetime)
						                        or (MONTH(o.DonationDatetime) = MONTH(@Date) and  YEAR(o.DonationDatetime) = YEAR(@Date))
						                        or (YEAR(o.DonationDatetime) = YEAR(@Date))
					                        )
				                        )
			                        )
			                        and (@Country is null 
					                        or ( 
						                        l.Country like '%' + @Country  + '%'
						                        or l.CountryCode like '%' + @Country  + '%'
					                        )
			                        )
			                        and (@State is null 
					                        or ( 
						                        l.StateOrProvince like '%' + @State  + '%'
						                        or l.StateOrProvinceCode like '%' + @State  + '%'
					                        )
			                        )
			                        and (@City is null 
					                        or ( 
						                        l.City like '%' + @City  + '%'
						                        or l.CityCode like '%' + @City  + '%'
					                        )
			                        )
			                        and (@Latitude is null or l.Latitude = @Latitude)
			                        and (@Latitude is null or l.Longitude = @Longitude)
			                        and (@Locality is null 
					                        or ( 
						                        l.StateOrProvince like '%' + @Locality  + '%'
						                        or l.StateOrProvinceCode like '%' + @Locality  + '%'
						                        or l.City like '%' + @Locality  + '%'
						                        or l.CityCode like '%' + @Locality  + '%'
						                        or l.Country like '%' + @Locality  + '%'
						                        or l.CountryCode like '%' + @Locality  + '%'
						                        or l.Neighborhood like '%' + @Locality  + '%'
					                        )
			                        )
			                        and (@SpecificLocality is null 
					                        or ( 
						                        fs.SpecificLocalityInEnglish like '%' + @SpecificLocality  + '%'
						                        or fs.SpecificLocalityOriginalLanguage like '%' + @SpecificLocality  + '%'
					                        )
			                        )
			                        and (@Family is null 
					                        or ( 
						                        f.Id = @Family
					                        )
	
			                        )
			                        and (@Subfamily is null 
					                        or ( 
						                        sf.Id = @Subfamily
					                        )
			                        )
			                        and (@Tribe is null 
					                        or  (
						                        t.Id = @Tribe
					                        )

			                        )
			                        and (@Genus is null 
					                        or ( 
						                        g.Id =  @Genus
					                        )
			                        )
			                        and (@Specie is null 
					                        or ( 
						                        s.Id  = @Specie
						                        or ss.SpeciesId = @Specie
					                        )
			                        )
			                        and (@InstitutionName is null 
					                        or (
						                        itt.NameInEnglish = '%' + @InstitutionName+ '%'
						                        or itt.NameOriginalLanguage like '%' + @InstitutionName + '%'
						                        or itt.Abbreviation like '%' + @InstitutionName + '%'
					                        )
			                        )
		                        )
	                        )
                            ORDER BY wi.AccessionCode ASC
                    ");
                return Connection.Query<WingResultDto>(query.ToString(), param).ToList();
            }
        }

        public IList<WingResultDto> GetByIds(string idsStr)
        {
            if (string.IsNullOrEmpty(idsStr)) return null;
            var ids = idsStr.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            return this.GetByIds(ids);
        }

        public IList<WingResultDto> GetByIds(int[] wingIds)
        {
            using (Connection)
            {
                if (wingIds == null || wingIds.Length < 1) return null;
                var ids = "";
                for (int i = 0; i < wingIds.Length; i++)
                {
                    ids += wingIds[i];
                    if (i != wingIds.Length - 1)
                        ids+=",";
                }
                var query = new StringBuilder();
                query.Append(QueryBase);
                query.Append($@"
                    wi.id in ({ids})
                 ");
                return Connection.Query<WingResultDto>(query.ToString()).ToList();
            }
        }

        public string QueryBase => @"
                        select 
	                          wi.Id
	                        , f.FamilyName
	                        , f.Id as 'FamilyId'
	                        , sf.SubfamilyName
	                        , g.GenericName as 'Genera'
	                        , g.Id  as 'GeneraId'
	                        , sg.SubgenericName
	                        , sg.Id as 'SubgenusId'
	                        , s.SpecificEpithet as 'Specie'
	                        , s.Id as 'SpecieId'
	                        , s.SpecificEpithet
	                        , ss.SubspeciesName
	                        , ss.Id as 'SubspeciesId'
	                        , t.TribeName
	                        , t.Id as  'TribeId'
	                        , i.Gender
	                        , wi.WingSide
	                        , l.Country
	                        , l.CountryCode
	                        , l.StateOrProvince as 'State'
	                        , l.StateOrProvinceCode as 'StateCode'
	                        , l.City
	                        , l.CityCode
	                        , fs.DateTime as 'SamplingDate'
                        from
	                        WingImage wi
	                        inner join WingPublication wp on wp.WingImageId = wi.Id 
	                        inner join Individual i on i.Id  =  wi.IndividualId
	                        inner join TaxonomicClassification tc on i.TaxonomicClassificationId = tc.Id
	                        inner join Origin o on o.Id  =  i.OriginId
	                        left join Subspecies ss on (ss.TaxonomicClassificationId = tc.Id) and (tc.ClassificationType = 'Subspecies')
	                        left join Species s on (s.Id = ss.SpeciesId) or ((s.TaxonomicClassificationId = tc.Id) and (tc.ClassificationType = 'Species'))
	                        left join Subgenus sg on (sg.Id = s.SubgenusId) or ((sg.TaxonomicClassificationId = tc.Id) and (tc.ClassificationType = 'Subgenus'))
	                        left join Genus g on (g.Id = sg.GenusId) or (g.Id = s.GenusId) or ((g.TaxonomicClassificationId = tc.Id) and (tc.ClassificationType = 'Genus'))
	                        left join Tribe t on (t.Id  = g.TribeId) or ((t.TaxonomicClassificationId = tc.Id) and (tc.ClassificationType = 'Tribe'))
	                        left join Subfamily sf on (sf.Id = t.SubfamilyId) or (sf.Id = g.SubfamilyId) or ((sf.TaxonomicClassificationId = tc.Id) and (tc.ClassificationType = 'Subamily'))
	                        left join Family f on (f.Id  = sf.FamilyId) or ((f.TaxonomicClassificationId = tc.Id) and (tc.ClassificationType = 'Family'))
	                        left join FieldSampling fs on fs.Id = o.FieldSamplingId
	                        left join Locality l on l.FieldSamplingId = fs.Id
	                        left join InternalControl ic on ic.IndividualId = i.Id
	                        left join Institution itt on itt.Id = o.DonorInstitutionId 
                        where
        ";
    }
}
