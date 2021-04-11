using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace IButantan.Wingbank.PackageGenerator
{
    public class WingbankPackageProcess
    {
        private const string c_connectionStringId = @"DbConnection";
        private const string c_tempPathId = @"TempPath";

        private const string c_queryWingImage =
            @"SELECT
				 WII.[Id] AS [WingImageId]
				,WII.[AccessionCode] AS [WingImageAccessionCode]
				,CASE
					WHEN WII.[WingSide] = 'L' THEN 'Left'
					WHEN WII.[WingSide] = 'R' Then 'Right'
					ELSE 'Unknow'
				 END AS [WingSide]
				,WII.[ImageDimension]
				,WII.[FileName] + WII.[ImageExtension] AS [FileName]
				,CAST(WII.[ImageZoom] AS VARCHAR(5)) + 'X' AS [ImageZoom]
				,WII.[AcquirementEquipment]
				,WII.[ImageDpi]
				,IND.[Id] AS [IndividualId]
				,IND.[DonationOriginalCode]
				,CASE
					WHEN IND.[Gender] = 'M' THEN 'Male'
					WHEN IND.[Gender] = 'F' THEN 'Female'
					ELSE 'Unknow'
				 END AS [Gender]
				,CLM.[ClassificationMethod]
				,CLM.[Reference]
				,ORI.[Id] AS [OriginId]
				,COL.[Id] AS [ColonyId]
				,COL.[Note] AS [ColonyNote]
				,COL.[PhotoPeriod] AS [ColonyPhotoPeriodo]
				,COL.[RelativeHumidity] AS [ColonyRelativeHumidity]
				,COL.[Strain] AS [ColonyStrain]
				,COL.[TemperatureControl] AS [ColonyTemperatureControl]
				,DON.[DonationDatetime]
				,DONINS.[Id] AS [DonationInstId]
				,DONINS.[Abbreviation] AS [DonationInstAbbreviation]
				,DONINS.[NameInEnglish] AS [DonationInstNameInEnglish]
				,DONINS.[NameOriginalLanguage] AS [DonationInstNameOriginalLanguage]
				,FIS.[Id] AS [FieldSamplingId]
				,FIS.[DateTime] AS [FieldSamplingDateTime]
				,ART.[Name] AS [FieldSamplingAreaTypeName]
				,FIS.[SpecificLocalityInEnglish] AS [FieldSamplingSpecificLocalityInEnglish]
				,FIS.[SpecificLocalityOriginalLanguage] AS [FieldSamplingSpecificLocalityOriginalLanguage]
				,FIS.[SurroundingDescription] AS [FieldSamplingSurroundingDescription]
				,STA.[Name] AS [FieldSamplingStageName]
				,MET.[Name] AS [FieldSamplingMethodName]
				,LOC.[GooglePlaceID] AS [LocalityGooglePlaceID]
				,LOC.[CountryCode] AS [LocalityCountryCode]
				,LOC.[Country] AS [LocalityCountry]
				,LOC.[StateOrProvinceCode] AS [LocalityStateOrProvinceCode]
				,LOC.[StateOrProvince] AS [LocalityStateOrProvince]
				,LOC.[City] AS [LocalityCity]
				,LOC.[Neighborhood] AS [LocalityNeighborhood]
				,LOC.[Address] AS [LocalityAddress]
				,LOC.[Number] AS [LocalityNumber]
				,LOC.[Zipcode] AS [LocalityZipcode]
				,LOC.[Latitude] AS [LocalityLatitude]
				,LOC.[Longitude] AS [LocalityLongitude]
				,LOC.[Altitude] AS [LocalityAltitude]
				,LOC.[Datum] AS [LocalityDatum]
				,TAC.[ClassificationType]
				,FAM.[FamilyName]
				,SUF.[SubfamilyName]
				,TRI.[TribeName]
				,GEN.[GenericName]
				,SUG.[SubgenericName]
				,SPE.[SpecificEpithet]
				,SUS.[SubspeciesName]
			FROM
				[dbo].[WingImage] WII
			INNER JOIN
				[dbo].[Individual] IND
				ON
					WII.[IndividualId] = IND.[Id]
			INNER JOIN
				[dbo].[Origin] ORI
				ON
					IND.[OriginId] = ORI.[Id]
			LEFT OUTER JOIN
				[dbo].[ClassificationMethodology] CLM
				ON
					IND.[ClassificationMethodologyId] = CLM.[Id]
			LEFT OUTER JOIN
				[dbo].[Colony] COL
				ON
					ORI.[ColonyId] = COL.[Id]
			LEFT OUTER JOIN
				[dbo].[Donation] DON
				ON
					ORI.[DonorInstitutionId] = DON.[InstitutionId]
				AND
					ORI.[DonationDatetime] = DON.[DonationDatetime]
			LEFT OUTER JOIN
				[dbo].[Institution] DONINS
				ON
					DON.[InstitutionId] = DONINS.[Id]
			LEFT OUTER JOIN
				[dbo].[FieldSampling] FIS
				ON
					ORI.[FieldSamplingId] = FIS.[Id]
			LEFT OUTER JOIN
				[dbo].[AreaType] ART
				ON
					FIS.[AreaTypeId] = ART.[Id]
			LEFT OUTER JOIN
				[dbo].[StageMethod] STM
				ON
					FIS.[StageMethodId] = STM.[Id]
			LEFT OUTER JOIN
				[dbo].[Stage] STA
				ON
					STM.[StageId] = STA.[Id]
			LEFT OUTER JOIN
				[dbo].[Method] MET
				ON
					STM.[MethodId] = MET.[Id]
			LEFT OUTER JOIN
				[dbo].[Locality] LOC
				ON
					FIS.[Id] = LOC.[FieldSamplingId]
			INNER JOIN
				[dbo].[TaxonomicClassification] TAC
				ON
					IND.[TaxonomicClassificationId] = TAC.[Id]
			LEFT OUTER JOIN
				[dbo].[Subspecies] SUS
				ON
				(
					TAC.[ClassificationType] = 'Subspecies'
					AND
					TAC.[Id] = SUS.[TaxonomicClassificationId]
				)
			LEFT OUTER JOIN
				[dbo].[Species] SPE
				ON
				(
					TAC.[ClassificationType] = 'Species'
					AND
					TAC.[Id] = SPE.[TaxonomicClassificationId]
				)
				OR
				SUS.[SpeciesId] = SPE.[Id]
			LEFT OUTER JOIN
				[dbo].[Subgenus] SUG
				ON
				(
					TAC.[ClassificationType] = 'Subgenus'
					AND
					TAC.[Id] = SUG.[TaxonomicClassificationId]
				)
				OR
				SPE.[SubgenusId] = SUG.[Id]
			LEFT OUTER JOIN
				[dbo].[Genus] GEN
				ON
				(
					TAC.[ClassificationType] = 'Genus'
					AND
					TAC.[Id] = GEN.[TaxonomicClassificationId]
				)
				OR
				SUG.[GenusId] = GEN.[Id]
				OR
				SPE.[GenusId] = GEN.[Id]
			LEFT OUTER JOIN
				[dbo].[Tribe] TRI
				ON
				(
					TAC.[ClassificationType] = 'Tribe'
					AND
					TAC.[Id] = TRI.[TaxonomicClassificationId]
				)
				OR
				GEN.[TribeId] = TRI.[Id]
			LEFT OUTER JOIN
				[dbo].[Subfamily] SUF
				ON
				(
					TAC.[ClassificationType] = 'Subfamily'
					AND
					TAC.[Id] = SUF.[TaxonomicClassificationId]
				)
				OR
				TRI.[SubfamilyId] = SUF.[Id]
				OR
				GEN.[SubfamilyId] = SUF.[Id]
			LEFT OUTER JOIN
				[dbo].[Family] FAM
				ON
				(
					TAC.[ClassificationType] = 'Family'
					AND
					TAC.[Id] = FAM.[TaxonomicClassificationId]
				)
				OR
				SUF.[FamilyId] = FAM.[Id]
			WHERE WII.[Id] IN ({0});";

        private const string c_queryPublicationList =
            @"SELECT
				 PUB.[Id] AS [PublicationId]
				,PUB.[Title] AS [PublicationTitle]
				,PUB.[Year] AS [PublicationYear]
				,PUB.[Publisher] AS [PublicationPublisher]
				,PUB.[Number] AS [PublicationNumber]
				,PUB.[Volume] AS [PublicationVolume]
				,PUB.[Url] AS [PublicationUrl]
				,PUB.[Doi] AS [PublicationDoi]
				,PUB.[Journal] AS [PublicationJournal]
			FROM
				[dbo].[WingPublication] WIP
			INNER JOIN
				[dbo].[Publication] PUB
				ON
					WIP.[PublicationId] = PUB.[Id]
			WHERE
				WIP.[WingImageId] = @WingImageId;";

        public const string c_queryAuthorsList =
            @"SELECT
				 PUA.[AuthorFirstName]
				,PUA.[AuthorLastName]
			FROM
				[dbo].[PublicationAuthor] PUA
			WHERE
				PUA.[PublicationId] = @publicationId;";

        public const string c_queryImageFile =
            @"SELECT TOP 1
				 WII.[AccessionCode]
				,WII.[ImageExtension]
				,WII.[ImageFile]
			FROM
				[dbo].[WingImage] WII
			WHERE
				WII.[Id] = @wingImageId;";

        public const string c_queryLandmark =
            @"SELECT
				 DENSE_RANK() OVER (ORDER BY LAN.[LandmarkAnnotationId]) AS [LandmarkOrder]
				,LAN.[HorizontalCoordinate]
				,LAN.[VerticalCoordinate]
			FROM
				[dbo].[Landmark] LAN
			INNER JOIN
				[dbo].[LandmarkAnnotation] LAA
				ON
					LAN.[LandmarkAnnotationId] = LAA.[Id]
			WHERE
				LAA.[WingImageId] = @wingImageId
			ORDER BY
				 [LandmarkOrder] ASC
				,LAN.[Id] ASC;";

        private SqlConnection m_connection;

        public string TempPath
        {
            get
            {
                return ConfigurationManager.AppSettings[c_tempPathId];
            }
        }

        public WingbankPackageProcess()
        {
            IniciarConexao();
        }

        private bool IniciarConexao()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[c_connectionStringId].ConnectionString;
                m_connection = new SqlConnection(connectionString);
                m_connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GerarPacote(IList<int> listaIdWingImage)
        {
            string arquivoPacote = null;
            var dirTempBase = CriarDiretorioTempBase();
            var reader = ExecutarQuery(listaIdWingImage);
            var wingImagesList = CarregarListaWingImage(reader);
            XmlDocument xmlDocument;
            string fileName;
            if (wingImagesList != null)
            {
                var dirInfo = CriarDiretorioTempDataHora(dirTempBase);
                foreach (var wingImage in wingImagesList.List)
                {
                    var wingImageId = Convert.ToInt32(wingImage.WingImageId);
                    var accessionCode = wingImage.AccessionCode;
                    xmlDocument = GerarXML(wingImage);
                    fileName = dirInfo.FullName + @"\Metadata\" + accessionCode + ".xml";
                    xmlDocument.Save(fileName);
                    var nomeArquivoImagem = ExtrairImagem(wingImageId, dirInfo.FullName + @"\Image");
                    ExtrairLandmark(wingImageId, accessionCode, nomeArquivoImagem, dirInfo.FullName + @"\Landmark");
                }
                xmlDocument = GerarXML(wingImagesList);
                fileName = dirInfo.FullName + @"\Metadata\FullInfos.xml";
                xmlDocument.Save(fileName);
                arquivoPacote = GerarArquivoZip(dirInfo, dirTempBase.Parent);
            }
            DestruirDiretorioTempBase(dirTempBase);
            return arquivoPacote;
        }


        public string GerarPacote(int idWingImage)
        {
            string arquivoPacote = null;
            var dirTempBase = CriarDiretorioTempBase();
            var reader = ExecutarQuery(new List<int>() { idWingImage });
            var wingImage = CarregarWingImage(reader);
            if (wingImage != null)
            {
                var wingImageId = Convert.ToInt32(wingImage.WingImageId);
                var accessionCode = wingImage.AccessionCode;
                var xmlDocument = GerarXML(wingImage);
                var dirInfo = CriarDiretorioTempAccessionCode(dirTempBase, accessionCode);
                var fileName = dirInfo.FullName + @"\" + accessionCode + ".xml";
                xmlDocument.Save(fileName);

                var nomeArquivoImagem = ExtrairImagem(wingImageId, dirInfo.FullName);
                ExtrairLandmark(wingImageId, accessionCode, nomeArquivoImagem, dirInfo.FullName);
                arquivoPacote = GerarArquivoZip(dirInfo, dirTempBase.Parent);
            }
            DestruirDiretorioTempBase(dirTempBase);
            return arquivoPacote;
        }

        private string GerarArquivoZip(DirectoryInfo source, DirectoryInfo target)
        {
            string zipPath = target.FullName + @"\" + source.Name + ".zip";
            ZipFile.CreateFromDirectory(source.FullName, zipPath, CompressionLevel.Optimal, false);
            return zipPath;
        }

        public DirectoryInfo CriarDiretorioTempDataHora(DirectoryInfo dirTempBase)
        {
            var nomeDiretorio = "Wingbank_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var directoryInfo = CriarDiretorioTemp(dirTempBase, nomeDiretorio);
            CriarSubdiretorios(directoryInfo);
            return directoryInfo;
        }

        public DirectoryInfo CriarDiretorioTempAccessionCode(DirectoryInfo dirTempBase, string accessionCode)
        {
            var nomeDiretorio = "Wingbank_" + accessionCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return CriarDiretorioTemp(dirTempBase, nomeDiretorio);
        }

        public DirectoryInfo CriarDiretorioTemp(DirectoryInfo dirTempBase, string nomeDiretorio)
        {
            var dirInfo = Directory.CreateDirectory(dirTempBase.FullName + @"\" + nomeDiretorio);
            return dirInfo;
        }

        public DirectoryInfo CriarDiretorioTempBase()
        {
            var dirInfo = Directory.CreateDirectory(TempPath + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            return dirInfo;
        }

        public void DestruirDiretorioTempBase(DirectoryInfo dirTempBase)
        {
            Directory.Delete(dirTempBase.FullName, true);
        }

        public void CriarSubdiretorios(DirectoryInfo dirInfo)
        {
            Directory.CreateDirectory(dirInfo.FullName + @"\Image");
            Directory.CreateDirectory(dirInfo.FullName + @"\Metadata");
            Directory.CreateDirectory(dirInfo.FullName + @"\Landmark");
        }

        private IDataReader ExecutarQuery(IList<int> listaIdWingImage)
        {
            var parametro = String.Join(",", listaIdWingImage);
            var query = string.Format(c_queryWingImage, parametro);
            using (var command = new SqlCommand(query, m_connection))
            {
                var reader = command.ExecuteReader();
                return reader;
            }
        }

        private XmlDocument GerarXML(object obj)
        {
            var doc = new XmlDocument();
            //doc.Schemas.Add("xwi", "https://wingbank.butantan.gov.br/XMLSchema");
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, obj);
                memoryStream.Position = 0;
                doc.Load(memoryStream);
            }
            return doc;
        }

        public WingImagesList CarregarListaWingImage(IDataReader reader)
        {
            var wingImagesList = new WingImagesList();
            wingImagesList.List = new List<WingImage>();
            WingImage wingImage;
            do
            {
                wingImage = CarregarWingImage(reader);
                if (wingImage != null)
                {
                    wingImagesList.List.Add(wingImage);
                }
            } while (wingImage != null);

            if (wingImagesList.List.Count > 0)
            {
                return wingImagesList;
            }
            else
            {
                return null;
            }
        }

        public WingImage CarregarWingImage(IDataReader reader)
        {
            if (reader.Read())
            {
                var wingImageId = Convert.ToInt32(reader["WingImageId"]);
                var wingImage = new WingImage()
                {
                    WingImageId = StrConv(reader["WingImageId"]),
                    AccessionCode = StrConv(reader["WingImageAccessionCode"]),
                    Side = StrConv(reader["WingSide"]),
                    ImageDimensions = StrConv(reader["ImageDimension"]),
                    FileName = StrConv(reader["FileName"]),
                    ImageZoom = StrConv(reader["ImageZoom"]),
                    AcquirementEquipment = CDataConv(reader["AcquirementEquipment"]),
                    ImageDPI = StrConv(reader["ImageDpi"]),
                    Individual = new Individual()
                    {
                        individualId = StrConv(reader["IndividualId"]),
                        Gender = StrConv(reader["Gender"]),
                        TaxonomicClassification = new TaxonomicClassification()
                        {
                            Type = StrConv(reader["ClassificationType"]),
                            Method = StrConv(reader["ClassificationMethod"]),
                            Reference = CDataConv(reader["Reference"]),
                            Family = StrConv(reader["FamilyName"]),
                            Subfamily = StrConv(reader["SubfamilyName"]),
                            Tribe = StrConv(reader["TribeName"]),
                            Genus = StrConv(reader["GenericName"]),
                            Subgenus = StrConv(reader["SubgenericName"]),
                            SpecificEpithet = StrConv(reader["SpecificEpithet"]),
                            SubspecificEpithet = StrConv(reader["SubspeciesName"])
                        }
                    }
                };

                if (reader["DonationDatetime"] != DBNull.Value)
                {
                    wingImage.Donation = new Donation()
                    {
                        DateTime = Convert.ToDateTime(reader["DonationDatetime"]),
                        Institution = new Institution()
                        {
                            InstitutionId = StrConv(reader["DonationInstId"]),
                            Abbreviation = StrConv(reader["DonationInstAbbreviation"]),
                            NameInEnglish = StrConv(reader["NameInEnglish"]),
                            NameOriginalLanguage = StrConv(reader["NameOriginalLanguage"])
                        },
                        OriginalCode = StrConv(reader["DonationOriginalCode"])
                    };
                }

                if (reader["FieldSamplingId"] != DBNull.Value)
                {
                    wingImage.FieldSampling = new FieldSampling()
                    {
                        FieldSamplingId = StrConv(reader["FieldSamplingId"]),
                        DateTime = Convert.ToDateTime(reader["FieldSamplingDateTime"]),
                        AreaType = StrConv(reader["FieldSamplingAreaTypeName"]),
                        SpecificLocalityInEnglish = CDataConv(reader["FieldSamplingSpecificLocalityInEnglish"]),
                        SpecificLocalityOriginalLanguage = CDataConv(reader["FieldSamplingSpecificLocalityOriginalLanguage"]),
                        SurroundingDescription = CDataConv(reader["FieldSamplingSurroundingDescription"]),
                        Stage = StrConv(reader["FieldSamplingStageName"]),
                        SamplingMethod = StrConv(reader["FieldSamplingMethodName"]),
                    };
                    if (reader["LocalityCountryCode"] != DBNull.Value)
                    {
                        wingImage.FieldSampling.Locality = new Locality()
                        {
                            CountryCode = StrConv(reader["LocalityCountryCode"]),
                            Country = StrConv(reader["LocalityCountry"]),
                            StateOrProvinceCode = StrConv(reader["LocalityStateOrProvinceCode"]),
                            StateOrProvince = StrConv(reader["LocalityStateOrProvince"]),
                            City = StrConv(reader["LocalityCity"]),
                            Neighborhood = StrConv(reader["LocalityNeighborhood"]),
                            Address = StrConv(reader["LocalityAddress"]),
                            Zipcode = StrConv(reader["LocalityZipcode"]),
                            Altitude = StrConv(reader["LocalityAltitude"])
                        };
                    }
                }

                if (reader["ColonyId"] != DBNull.Value)
                {
                    wingImage.Colony = new Colony
                    {
                        ColonyId = StrConv(reader["ColonyId"]),
                        RelaviteHumidity = StrConv(reader["ColonyRelativeHumidity"]),
                        TemperatureControl = StrConv(reader["ColonyTemperatureControl"]),
                        Strain = StrConv(reader["ColonyStrain"]),
                        Note = CDataConv(reader["ColonyNote"])
                    };
                }

                wingImage.PublicationList = CarregarListaPublicacao(wingImageId);
                return wingImage;
            }
            else
            {
                return null;
            }
        }

        public List<Publication> CarregarListaPublicacao(int wingImageId)
        {
            var lista = new List<Publication>();
            var command = new SqlCommand(c_queryPublicationList, m_connection);
            command.Parameters.Add(new SqlParameter("@WingImageId", wingImageId));
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var publicationId = Convert.ToInt32(reader["PublicationId"]);
                var publication = new Publication()
                {
                    PublicationId = StrConv(reader["PublicationId"]),
                    Title = CDataConv(reader["PublicationTitle"]),
                    Year = StrConv(reader["PublicationYear"]),
                    Publisher = StrConv(reader["PublicationPublisher"]),
                    Number = StrConv(reader["PublicationNumber"]),
                    Volume = StrConv(reader["PublicationVolume"]),
                    Url = CDataConv(reader["PublicationUrl"]),
                    Doi = CDataConv(reader["PublicationDoi"]),
                    Jornal = CDataConv(reader["PublicationJournal"]),
                    AuthorsList = CarregarListaAutores(publicationId)
                };
                lista.Add(publication);
            }

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                return null;
            }
        }

        private List<Author> CarregarListaAutores(int publicationId)
        {
            var lista = new List<Author>();

            var command = new SqlCommand(c_queryAuthorsList, m_connection);
            command.Parameters.Add(new SqlParameter("@publicationId", publicationId));
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var author = new Author()
                {
                    FirstName = StrConv(reader["AuthorFirstName"]),
                    LastName = StrConv(reader["AuthorLastName"])
                };
                lista.Add(author);
            }

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                return null;
            }
        }

        private string StrConv(object obj)
        {
            if (obj != DBNull.Value)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }


        private XmlCDataSection CDataConv(object obj)
        {
            if (obj != DBNull.Value)
            {
                return new XmlDocument().CreateCDataSection(obj.ToString());
            }
            else
            {
                return null;
            }
        }

        private string ExtrairImagem(int wingImageId, string diretorio)
        {
            string nomeArquivo = string.Empty;
            using (var command = new SqlCommand(c_queryImageFile, m_connection))
            {
                command.Parameters.Add(new SqlParameter("@wingImageId", wingImageId));
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nomeArquivo = StrConv(reader["AccessionCode"]) + StrConv(reader["ImageExtension"]);
                        var nomearquivoCaminho = diretorio + @"\" + nomeArquivo;
                        var image = (byte[])reader["ImageFile"];
                        using (var stream = File.OpenWrite(nomearquivoCaminho))
                        {
                            stream.Write(image, 0, image.Length);
                            stream.Flush();
                        }
                    }
                }
            }
            return nomeArquivo;
        }

        private void ExtrairLandmark(int wingImageId, string accessionCode, string nomeArquivoImagem, string diretorio)
        {
            using (var command = new SqlCommand(c_queryLandmark, m_connection))
            {
                command.Parameters.Add(new SqlParameter("@wingImageId", wingImageId));
                using (var reader = command.ExecuteReader())
                {
                    int count = 0;
                    string landmarkOrder = string.Empty;
                    string nomeArquivoLandmark = string.Empty;
                    FileStream fileStream = null;
                    StreamWriter streamWriter = null;
                    StringBuilder sb = null;

                    while (reader.Read())
                    {
                        string newLandmarkOrder = reader["LandmarkOrder"].ToString();
                        if (!newLandmarkOrder.Equals(landmarkOrder))
                        {
                            if (streamWriter != null)
                            {
                                streamWriter.WriteLine("LM=" + count.ToString());
                                streamWriter.Write(sb.ToString());
                                streamWriter.Write("IMAGE=" + nomeArquivoImagem);
                                streamWriter.Flush();
                                streamWriter.Close();
                                streamWriter.Dispose();
                                streamWriter = null;
                                fileStream.Close();
                                fileStream.Dispose();
                                fileStream = null;
                                sb = null;
                            }

                            count = 1;
                            landmarkOrder = newLandmarkOrder;
                            nomeArquivoLandmark = diretorio + @"\" + accessionCode + "_" + landmarkOrder + ".tps";
                            fileStream = File.OpenWrite(nomeArquivoLandmark);
                            streamWriter = new StreamWriter(fileStream);
                            sb = new StringBuilder();
                        }
                        else
                        {
                            count++;
                        }

                        var horizontalCoord = Convert.ToDouble(reader["HorizontalCoordinate"]);
                        var verticalCoord = Convert.ToDouble(reader["VerticalCoordinate"]);
                        sb.AppendLine(horizontalCoord.ToString("0.00000") + " " + verticalCoord.ToString("0.00000"));
                    }

                    if (streamWriter != null)
                    {
                        streamWriter.WriteLine("LM=" + count.ToString());
                        streamWriter.Write(sb.ToString().Replace(",", "."));
                        streamWriter.Write("IMAGE=" + nomeArquivoImagem);
                        streamWriter.Flush();
                        streamWriter.Close();
                        streamWriter.Dispose();
                        streamWriter = null;
                        fileStream.Close();
                        fileStream.Dispose();
                        fileStream = null;
                        sb = null;
                    }
                }
            }
        }
    }
}
