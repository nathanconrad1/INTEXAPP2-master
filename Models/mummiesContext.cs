using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace INTEXAPP2.Models
{
    public partial class mummiesContext : DbContext
    {
        public mummiesContext()
        {
        }

        public mummiesContext(DbContextOptions<mummiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Analysis> Analyses { get; set; }
        public virtual DbSet<AnalysisTextile> AnalysisTextiles { get; set; }
        public virtual DbSet<Artifactfagelgamousregister> Artifactfagelgamousregisters { get; set; }
        public virtual DbSet<ArtifactfagelgamousregisterBurialmain> ArtifactfagelgamousregisterBurialmains { get; set; }
        public virtual DbSet<Artifactkomaushimregister> Artifactkomaushimregisters { get; set; }
        public virtual DbSet<ArtifactkomaushimregisterBurialmain> ArtifactkomaushimregisterBurialmains { get; set; }
        public virtual DbSet<Biological> Biologicals { get; set; }
        public virtual DbSet<BiologicalC14> BiologicalC14s { get; set; }
        public virtual DbSet<Bodyanalysischart> Bodyanalysischarts { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Burialdetail> Burialdetails { get; set; }
        public virtual DbSet<Burialmain> Burialmains { get; set; }
        public virtual DbSet<BurialmainBiological> BurialmainBiologicals { get; set; }
        public virtual DbSet<BurialmainBodyanalysischart> BurialmainBodyanalysischarts { get; set; }
        public virtual DbSet<BurialmainCranium> BurialmainCrania { get; set; }
        public virtual DbSet<BurialmainTextile> BurialmainTextiles { get; set; }
        public virtual DbSet<Burialmainbodyanalysis> Burialmainbodyanalyses { get; set; }
        public virtual DbSet<Burialmaintextiledetail> Burialmaintextiledetails { get; set; }
        public virtual DbSet<C14> C14s { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<ColorTextile> ColorTextiles { get; set; }
        public virtual DbSet<Cranium> Crania { get; set; }
        public virtual DbSet<Decoration> Decorations { get; set; }
        public virtual DbSet<DecorationTextile> DecorationTextiles { get; set; }
        public virtual DbSet<Dimension> Dimensions { get; set; }
        public virtual DbSet<DimensionTextile> DimensionTextiles { get; set; }
        public virtual DbSet<Fulldatamummy> Fulldatamummies { get; set; }
        public virtual DbSet<Newsarticle> Newsarticles { get; set; }
        public virtual DbSet<PhotodataTextile> PhotodataTextiles { get; set; }
        public virtual DbSet<Photodatum> Photodata { get; set; }
        public virtual DbSet<Photoform> Photoforms { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<StructureTextile> StructureTextiles { get; set; }
        public virtual DbSet<Teammember> Teammembers { get; set; }
        public virtual DbSet<Testingstuff> Testingstuffs { get; set; }
        public virtual DbSet<Textile> Textiles { get; set; }
        public virtual DbSet<Textiledetail> Textiledetails { get; set; }
        public virtual DbSet<Textilefunction> Textilefunctions { get; set; }
        public virtual DbSet<TextilefunctionTextile> TextilefunctionTextiles { get; set; }
        public virtual DbSet<Websitetable> Websitetables { get; set; }
        public virtual DbSet<Yarnmanipulation> Yarnmanipulations { get; set; }
        public virtual DbSet<YarnmanipulationTextile> YarnmanipulationTextiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=ec2-34-224-153-247.compute-1.amazonaws.com;Database=mummies;Uid=root;Pwd=HorsesCowsAndMagpies1!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analysis>(entity =>
            {
                entity.ToTable("analysis");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Analysisid)
                    .HasColumnType("int(11)")
                    .HasColumnName("analysisid");

                entity.Property(e => e.Analysistype)
                    .HasColumnType("int(11)")
                    .HasColumnName("analysistype");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp")
                    .HasColumnName("date");

                entity.Property(e => e.Doneby)
                    .HasMaxLength(100)
                    .HasColumnName("doneby");
            });

            modelBuilder.Entity<AnalysisTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainAnalysisid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("analysis_textile");

                entity.Property(e => e.MainAnalysisid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$analysisid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Artifactfagelgamousregister>(entity =>
            {
                entity.ToTable("artifactfagelgamousregister");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Coordinateset)
                    .HasMaxLength(200)
                    .HasColumnName("coordinateset");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Photographed)
                    .HasMaxLength(3)
                    .HasColumnName("photographed");

                entity.Property(e => e.Registernum)
                    .HasMaxLength(30)
                    .HasColumnName("registernum");
            });

            modelBuilder.Entity<ArtifactfagelgamousregisterBurialmain>(entity =>
            {
                entity.HasKey(e => new { e.MainArtifactfagelgamousregisterid, e.MainBurialmainid })
                    .HasName("PRIMARY");

                entity.ToTable("artifactfagelgamousregister_burialmain");

                entity.Property(e => e.MainArtifactfagelgamousregisterid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$artifactfagelgamousregisterid");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");
            });

            modelBuilder.Entity<Artifactkomaushimregister>(entity =>
            {
                entity.ToTable("artifactkomaushimregister");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Currentlocation)
                    .HasMaxLength(200)
                    .HasColumnName("currentlocation");

                entity.Property(e => e.Date)
                    .HasMaxLength(200)
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(200)
                    .HasColumnName("dimensions");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("timestamp")
                    .HasColumnName("entrydate");

                entity.Property(e => e.Excavatornum)
                    .HasMaxLength(200)
                    .HasColumnName("excavatornum");

                entity.Property(e => e.Finder)
                    .HasMaxLength(200)
                    .HasColumnName("finder");

                entity.Property(e => e.Material)
                    .HasMaxLength(200)
                    .HasColumnName("material");

                entity.Property(e => e.Number)
                    .HasMaxLength(200)
                    .HasColumnName("number");

                entity.Property(e => e.Photos)
                    .HasMaxLength(3)
                    .HasColumnName("photos");

                entity.Property(e => e.Position)
                    .HasMaxLength(200)
                    .HasColumnName("position");

                entity.Property(e => e.Provenance)
                    .HasMaxLength(200)
                    .HasColumnName("provenance");

                entity.Property(e => e.Qualityphotos)
                    .HasMaxLength(3)
                    .HasColumnName("qualityphotos");

                entity.Property(e => e.Rehousedto)
                    .HasMaxLength(200)
                    .HasColumnName("rehousedto");

                entity.Property(e => e.Remarks)
                    .HasColumnType("text")
                    .HasColumnName("remarks");
            });

            modelBuilder.Entity<ArtifactkomaushimregisterBurialmain>(entity =>
            {
                entity.HasKey(e => new { e.MainArtifactkomaushimregisterid, e.MainBurialmainid })
                    .HasName("PRIMARY");

                entity.ToTable("artifactkomaushimregister_burialmain");

                entity.Property(e => e.MainArtifactkomaushimregisterid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$artifactkomaushimregisterid");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");
            });

            modelBuilder.Entity<Biological>(entity =>
            {
                entity.ToTable("biological");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Bagnumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("bagnumber");

                entity.Property(e => e.Clusternumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp")
                    .HasColumnName("date");

                entity.Property(e => e.Initials)
                    .HasMaxLength(200)
                    .HasColumnName("initials");

                entity.Property(e => e.Notes)
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.Previouslysampled)
                    .HasMaxLength(200)
                    .HasColumnName("previouslysampled");

                entity.Property(e => e.Racknumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("racknumber");
            });

            modelBuilder.Entity<BiologicalC14>(entity =>
            {
                entity.HasKey(e => new { e.MainBiologicalid, e.MainC14id })
                    .HasName("PRIMARY");

                entity.ToTable("biological_c14");

                entity.Property(e => e.MainBiologicalid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$biologicalid");

                entity.Property(e => e.MainC14id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$c14id");
            });

            modelBuilder.Entity<Bodyanalysischart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bodyanalysischart");

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.BurialNumber).HasMaxLength(255);

                entity.Property(e => e.CariesPeriodontalDisease)
                    .HasMaxLength(255)
                    .HasColumnName("Caries_Periodontal_Disease");

                entity.Property(e => e.DateofExamination).HasMaxLength(255);

                entity.Property(e => e.DorsalPittingBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("DorsalPitting (boolean)");

                entity.Property(e => e.EastWest).HasMaxLength(255);

                entity.Property(e => e.Femur).HasMaxLength(255);

                entity.Property(e => e.FemurHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Gonion).HasMaxLength(255);

                entity.Property(e => e.HairColor).HasMaxLength(255);

                entity.Property(e => e.Humerus).HasMaxLength(255);

                entity.Property(e => e.HumerusHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LamboidSuture).HasMaxLength(255);

                entity.Property(e => e.MedialIpRamus)
                    .HasMaxLength(255)
                    .HasColumnName("Medial_IP_Ramus");

                entity.Property(e => e.NorthSouth).HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(859);

                entity.Property(e => e.NuchalCrest).HasMaxLength(255);

                entity.Property(e => e.Observations).HasMaxLength(830);

                entity.Property(e => e.OrbitEdge).HasMaxLength(255);

                entity.Property(e => e.Osteophytosis).HasMaxLength(255);

                entity.Property(e => e.ParietalBossing).HasMaxLength(255);

                entity.Property(e => e.PreauricularSulcusBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("PreauricularSulcus (Boolean)");

                entity.Property(e => e.PubicBone).HasMaxLength(255);

                entity.Property(e => e.Robust).HasMaxLength(255);

                entity.Property(e => e.SciaticNotch).HasMaxLength(255);

                entity.Property(e => e.SphenooccipitalSynchrondrosis).HasMaxLength(255);

                entity.Property(e => e.SquamosSuture).HasMaxLength(255);

                entity.Property(e => e.SubpubicAngle).HasMaxLength(255);

                entity.Property(e => e.SupraorbitalRidges).HasMaxLength(255);

                entity.Property(e => e.ToothAttrition).HasMaxLength(255);

                entity.Property(e => e.ToothEruption).HasMaxLength(255);

                entity.Property(e => e.ToothEruptionAgeEstimate).HasMaxLength(255);

                entity.Property(e => e.VentralArc).HasMaxLength(255);

                entity.Property(e => e.ZygomaticCrest).HasMaxLength(255);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(200)
                    .HasColumnName("author");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Link)
                    .HasColumnType("text")
                    .HasColumnName("link");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Burialdetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("burialdetails");

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(200)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(200)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(200)
                    .HasColumnName("area");

                entity.Property(e => e.Burialid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasMaxLength(5)
                    .HasColumnName("burialmaterials");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.CariesPeriodontalDisease)
                    .HasMaxLength(255)
                    .HasColumnName("Caries_Periodontal_Disease");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(200)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(200)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.DateofExamination).HasMaxLength(255);

                entity.Property(e => e.Dateofexcavation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasMaxLength(200)
                    .HasColumnName("depth");

                entity.Property(e => e.DorsalPittingBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("DorsalPitting (boolean)");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(200)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Excavationrecorder)
                    .HasMaxLength(100)
                    .HasColumnName("excavationrecorder");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(200)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Femur).HasMaxLength(255);

                entity.Property(e => e.FemurHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Gonion).HasMaxLength(255);

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .HasColumnName("goods");

                entity.Property(e => e.Hair)
                    .HasMaxLength(5)
                    .HasColumnName("hair");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(200)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(200)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Humerus).HasMaxLength(255);

                entity.Property(e => e.HumerusHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.LamboidSuture).HasMaxLength(255);

                entity.Property(e => e.Length)
                    .HasMaxLength(200)
                    .HasColumnName("length");

                entity.Property(e => e.MedialIpRamus)
                    .HasMaxLength(255)
                    .HasColumnName("Medial_IP_Ramus");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(200)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Notes).HasMaxLength(859);

                entity.Property(e => e.NuchalCrest).HasMaxLength(255);

                entity.Property(e => e.Observations).HasMaxLength(830);

                entity.Property(e => e.OrbitEdge).HasMaxLength(255);

                entity.Property(e => e.Osteophytosis).HasMaxLength(255);

                entity.Property(e => e.ParietalBossing).HasMaxLength(255);

                entity.Property(e => e.Photos)
                    .HasMaxLength(5)
                    .HasColumnName("photos");

                entity.Property(e => e.PreauricularSulcusBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("PreauricularSulcus (Boolean)");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(200)
                    .HasColumnName("preservation");

                entity.Property(e => e.PubicBone).HasMaxLength(255);

                entity.Property(e => e.RightArea)
                    .HasMaxLength(255)
                    .HasColumnName("Right_Area");

                entity.Property(e => e.RightBurialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Right_BurialNumber");

                entity.Property(e => e.RightEastWest)
                    .HasMaxLength(255)
                    .HasColumnName("Right_EastWest");

                entity.Property(e => e.RightHairColor)
                    .HasMaxLength(255)
                    .HasColumnName("Right_HairColor");

                entity.Property(e => e.RightId).HasColumnName("Right_id");

                entity.Property(e => e.RightNorthSouth)
                    .HasMaxLength(255)
                    .HasColumnName("Right_NorthSouth");

                entity.Property(e => e.RightSquareEastWest).HasColumnName("Right_SquareEastWest");

                entity.Property(e => e.RightSquareNorthSouth).HasColumnName("Right_SquareNorthSouth");

                entity.Property(e => e.Robust).HasMaxLength(255);

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(200)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.SciaticNotch).HasMaxLength(255);

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .HasColumnName("sex");

                entity.Property(e => e.Shaftnumber)
                    .HasMaxLength(200)
                    .HasColumnName("shaftnumber");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(200)
                    .HasColumnName("southtohead");

                entity.Property(e => e.SphenooccipitalSynchrondrosis).HasMaxLength(255);

                entity.Property(e => e.SquamosSuture).HasMaxLength(255);

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(200)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(200)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.SubpubicAngle).HasMaxLength(255);

                entity.Property(e => e.SupraorbitalRidges).HasMaxLength(255);

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.ToothAttrition).HasMaxLength(255);

                entity.Property(e => e.ToothEruption).HasMaxLength(255);

                entity.Property(e => e.ToothEruptionAgeEstimate).HasMaxLength(255);

                entity.Property(e => e.VentralArc).HasMaxLength(255);

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(200)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(200)
                    .HasColumnName("wrapping");

                entity.Property(e => e.ZygomaticCrest).HasMaxLength(255);
            });

            modelBuilder.Entity<Burialmain>(entity =>
            {
                entity.ToTable("burialmain");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(200)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(200)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(200)
                    .HasColumnName("area");

                entity.Property(e => e.Burialid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasMaxLength(5)
                    .HasColumnName("burialmaterials");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(200)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(200)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.Dateofexcavation)
                    .HasColumnType("timestamp")
                    .HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasMaxLength(200)
                    .HasColumnName("depth");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(200)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Excavationrecorder)
                    .HasMaxLength(100)
                    .HasColumnName("excavationrecorder");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(200)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .HasColumnName("goods");

                entity.Property(e => e.Hair)
                    .HasMaxLength(5)
                    .HasColumnName("hair");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(200)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(200)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Length)
                    .HasMaxLength(200)
                    .HasColumnName("length");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(200)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Photos)
                    .HasMaxLength(5)
                    .HasColumnName("photos");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(200)
                    .HasColumnName("preservation");

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(200)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .HasColumnName("sex");

                entity.Property(e => e.Shaftnumber)
                    .HasMaxLength(200)
                    .HasColumnName("shaftnumber");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(200)
                    .HasColumnName("southtohead");

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(200)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(200)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(200)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(200)
                    .HasColumnName("wrapping");
            });

            modelBuilder.Entity<BurialmainBiological>(entity =>
            {
                entity.HasKey(e => new { e.MainBurialmainid, e.MainBiologicalid })
                    .HasName("PRIMARY");

                entity.ToTable("burialmain_biological");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");

                entity.Property(e => e.MainBiologicalid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$biologicalid");
            });

            modelBuilder.Entity<BurialmainBodyanalysischart>(entity =>
            {
                entity.HasKey(e => new { e.MainBurialmainid, e.MainBodyanalysischartid })
                    .HasName("PRIMARY");

                entity.ToTable("burialmain_bodyanalysischart");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");

                entity.Property(e => e.MainBodyanalysischartid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$bodyanalysischartid");
            });

            modelBuilder.Entity<BurialmainCranium>(entity =>
            {
                entity.HasKey(e => new { e.MainBurialmainid, e.MainCraniumid })
                    .HasName("PRIMARY");

                entity.ToTable("burialmain_cranium");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");

                entity.Property(e => e.MainCraniumid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$craniumid");
            });

            modelBuilder.Entity<BurialmainTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainBurialmainid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("burialmain_textile");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Burialmainbodyanalysis>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("burialmainbodyanalysis");

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(200)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(200)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(200)
                    .HasColumnName("area");

                entity.Property(e => e.Burialid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasMaxLength(5)
                    .HasColumnName("burialmaterials");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.CariesPeriodontalDisease)
                    .HasMaxLength(255)
                    .HasColumnName("Caries_Periodontal_Disease");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(200)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(200)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.DateofExamination).HasMaxLength(255);

                entity.Property(e => e.Dateofexcavation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasMaxLength(200)
                    .HasColumnName("depth");

                entity.Property(e => e.DorsalPittingBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("DorsalPitting (boolean)");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(200)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Excavationrecorder)
                    .HasMaxLength(100)
                    .HasColumnName("excavationrecorder");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(200)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Femur).HasMaxLength(255);

                entity.Property(e => e.FemurHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Gonion).HasMaxLength(255);

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .HasColumnName("goods");

                entity.Property(e => e.Hair)
                    .HasMaxLength(5)
                    .HasColumnName("hair");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(200)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(200)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Humerus).HasMaxLength(255);

                entity.Property(e => e.HumerusHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.LamboidSuture).HasMaxLength(255);

                entity.Property(e => e.Length)
                    .HasMaxLength(200)
                    .HasColumnName("length");

                entity.Property(e => e.MedialIpRamus)
                    .HasMaxLength(255)
                    .HasColumnName("Medial_IP_Ramus");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(200)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Notes).HasMaxLength(859);

                entity.Property(e => e.NuchalCrest).HasMaxLength(255);

                entity.Property(e => e.Observations).HasMaxLength(830);

                entity.Property(e => e.OrbitEdge).HasMaxLength(255);

                entity.Property(e => e.Osteophytosis).HasMaxLength(255);

                entity.Property(e => e.ParietalBossing).HasMaxLength(255);

                entity.Property(e => e.Photos)
                    .HasMaxLength(5)
                    .HasColumnName("photos");

                entity.Property(e => e.PreauricularSulcusBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("PreauricularSulcus (Boolean)");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(200)
                    .HasColumnName("preservation");

                entity.Property(e => e.PubicBone).HasMaxLength(255);

                entity.Property(e => e.RightArea)
                    .HasMaxLength(255)
                    .HasColumnName("Right_Area");

                entity.Property(e => e.RightBurialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Right_BurialNumber");

                entity.Property(e => e.RightEastWest)
                    .HasMaxLength(255)
                    .HasColumnName("Right_EastWest");

                entity.Property(e => e.RightHairColor)
                    .HasMaxLength(255)
                    .HasColumnName("Right_HairColor");

                entity.Property(e => e.RightId).HasColumnName("Right_id");

                entity.Property(e => e.RightNorthSouth)
                    .HasMaxLength(255)
                    .HasColumnName("Right_NorthSouth");

                entity.Property(e => e.RightSquareEastWest).HasColumnName("Right_SquareEastWest");

                entity.Property(e => e.RightSquareNorthSouth).HasColumnName("Right_SquareNorthSouth");

                entity.Property(e => e.Robust).HasMaxLength(255);

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(200)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.SciaticNotch).HasMaxLength(255);

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .HasColumnName("sex");

                entity.Property(e => e.Shaftnumber)
                    .HasMaxLength(200)
                    .HasColumnName("shaftnumber");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(200)
                    .HasColumnName("southtohead");

                entity.Property(e => e.SphenooccipitalSynchrondrosis).HasMaxLength(255);

                entity.Property(e => e.SquamosSuture).HasMaxLength(255);

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(200)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(200)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.SubpubicAngle).HasMaxLength(255);

                entity.Property(e => e.SupraorbitalRidges).HasMaxLength(255);

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.ToothAttrition).HasMaxLength(255);

                entity.Property(e => e.ToothEruption).HasMaxLength(255);

                entity.Property(e => e.ToothEruptionAgeEstimate).HasMaxLength(255);

                entity.Property(e => e.VentralArc).HasMaxLength(255);

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(200)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(200)
                    .HasColumnName("wrapping");

                entity.Property(e => e.ZygomaticCrest).HasMaxLength(255);
            });

            modelBuilder.Entity<Burialmaintextiledetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("burialmaintextiledetails");

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(200)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(200)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(200)
                    .HasColumnName("area");

                entity.Property(e => e.Burialid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasMaxLength(5)
                    .HasColumnName("burialmaterials");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(200)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Colorid)
                    .HasColumnType("int(11)")
                    .HasColumnName("colorid");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(200)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.Dateofexcavation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasMaxLength(200)
                    .HasColumnName("depth");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Direction)
                    .HasMaxLength(200)
                    .HasColumnName("direction");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(200)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Estimatedperiod)
                    .HasMaxLength(200)
                    .HasColumnName("estimatedperiod");

                entity.Property(e => e.Excavationrecorder)
                    .HasMaxLength(100)
                    .HasColumnName("excavationrecorder");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(200)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .HasColumnName("goods");

                entity.Property(e => e.Hair)
                    .HasMaxLength(5)
                    .HasColumnName("hair");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(200)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(200)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.LeftRightId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("Left_Right_id");

                entity.Property(e => e.LeftRightMainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("Left_Right_main$textileid");

                entity.Property(e => e.LeftRightValue)
                    .HasColumnType("text")
                    .HasColumnName("Left_Right_value");

                entity.Property(e => e.Length)
                    .HasMaxLength(200)
                    .HasColumnName("length");

                entity.Property(e => e.Locale)
                    .HasMaxLength(200)
                    .HasColumnName("locale");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");

                entity.Property(e => e.MainColorid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$colorid");

                entity.Property(e => e.MainStructureid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$structureid");

                entity.Property(e => e.MainTextilefunctionid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textilefunctionid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(200)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Photographeddate)
                    .HasColumnType("datetime")
                    .HasColumnName("photographeddate");

                entity.Property(e => e.Photos)
                    .HasMaxLength(5)
                    .HasColumnName("photos");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(200)
                    .HasColumnName("preservation");

                entity.Property(e => e.RightId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("Right_id");

                entity.Property(e => e.RightMainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("Right_main$textileid");

                entity.Property(e => e.RightRightId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("Right_Right_id");

                entity.Property(e => e.RightValue)
                    .HasColumnType("text")
                    .HasColumnName("Right_value");

                entity.Property(e => e.Sampledate)
                    .HasColumnType("datetime")
                    .HasColumnName("sampledate");

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(200)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .HasColumnName("sex");

                entity.Property(e => e.Shaftnumber)
                    .HasMaxLength(200)
                    .HasColumnName("shaftnumber");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(200)
                    .HasColumnName("southtohead");

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(200)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(200)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.Structureid)
                    .HasColumnType("int(11)")
                    .HasColumnName("structureid");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.Textilefunctionid)
                    .HasColumnType("int(11)")
                    .HasColumnName("textilefunctionid");

                entity.Property(e => e.Textileid)
                    .HasColumnType("int(11)")
                    .HasColumnName("textileid");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(200)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(200)
                    .HasColumnName("wrapping");
            });

            modelBuilder.Entity<C14>(entity =>
            {
                entity.ToTable("c14");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Agebp)
                    .HasColumnType("int(11)")
                    .HasColumnName("agebp");

                entity.Property(e => e.C14lab)
                    .HasMaxLength(200)
                    .HasColumnName("c14lab");

                entity.Property(e => e.Calendardate)
                    .HasColumnType("int(11)")
                    .HasColumnName("calendardate");

                entity.Property(e => e.Calibrateddateavg)
                    .HasColumnType("int(11)")
                    .HasColumnName("calibrateddateavg");

                entity.Property(e => e.Calibrateddatemax)
                    .HasColumnType("int(11)")
                    .HasColumnName("calibrateddatemax");

                entity.Property(e => e.Calibrateddatemin)
                    .HasColumnType("int(11)")
                    .HasColumnName("calibrateddatemin");

                entity.Property(e => e.Calibratedspan)
                    .HasColumnType("int(11)")
                    .HasColumnName("calibratedspan");

                entity.Property(e => e.Category)
                    .HasMaxLength(200)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Foci)
                    .HasMaxLength(200)
                    .HasColumnName("foci");

                entity.Property(e => e.Location)
                    .HasColumnType("text")
                    .HasColumnName("location");

                entity.Property(e => e.Questions)
                    .HasColumnType("text")
                    .HasColumnName("questions");

                entity.Property(e => e.Rack)
                    .HasColumnType("int(11)")
                    .HasColumnName("rack");

                entity.Property(e => e.Size)
                    .HasColumnType("int(11)")
                    .HasColumnName("size");

                entity.Property(e => e.Tubenumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("tubenumber");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Colorid)
                    .HasColumnType("int(11)")
                    .HasColumnName("colorid");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<ColorTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainColorid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("color_textile");

                entity.Property(e => e.MainColorid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$colorid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Cranium>(entity =>
            {
                entity.ToTable("cranium");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AlphaCore)
                    .HasPrecision(28, 8)
                    .HasColumnName("alpha_core");

                entity.Property(e => e.BasionBregmaHeight)
                    .HasPrecision(28, 8)
                    .HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion)
                    .HasPrecision(28, 8)
                    .HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength)
                    .HasPrecision(28, 8)
                    .HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter)
                    .HasPrecision(28, 8)
                    .HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.InterobitalBreadth)
                    .HasPrecision(28, 8)
                    .HasColumnName("interobital_breadth");

                entity.Property(e => e.InterorbitalBreadth)
                    .HasPrecision(28, 8)
                    .HasColumnName("interorbital_breadth");

                entity.Property(e => e.InterorbitalSubtense)
                    .HasPrecision(28, 8)
                    .HasColumnName("interorbital_subtense");

                entity.Property(e => e.MaxNasalBreadth)
                    .HasPrecision(28, 8)
                    .HasColumnName("max_nasal_breadth");

                entity.Property(e => e.Maxcraniumbreadth)
                    .HasPrecision(28, 8)
                    .HasColumnName("maxcraniumbreadth");

                entity.Property(e => e.Maxcraniumlength)
                    .HasPrecision(28, 8)
                    .HasColumnName("maxcraniumlength");

                entity.Property(e => e.MidOrbitalBreadth)
                    .HasPrecision(28, 8)
                    .HasColumnName("mid_orbital_breadth");

                entity.Property(e => e.MidOrbitalSubtense)
                    .HasPrecision(28, 8)
                    .HasColumnName("mid_orbital_subtense");

                entity.Property(e => e.NasionProsthionUpper)
                    .HasPrecision(28, 8)
                    .HasColumnName("nasion_prosthion_upper");

                entity.Property(e => e.NasoAlphaSubtense)
                    .HasPrecision(28, 8)
                    .HasColumnName("naso_alpha__subtense");
            });

            modelBuilder.Entity<Decoration>(entity =>
            {
                entity.ToTable("decoration");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Decorationid)
                    .HasColumnType("int(11)")
                    .HasColumnName("decorationid");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<DecorationTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainDecorationid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("decoration_textile");

                entity.Property(e => e.MainDecorationid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$decorationid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.ToTable("dimension");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Dimensionid)
                    .HasColumnType("int(11)")
                    .HasColumnName("dimensionid");

                entity.Property(e => e.Dimensiontype)
                    .HasColumnType("text")
                    .HasColumnName("dimensiontype");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<DimensionTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainDimensionid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("dimension_textile");

                entity.Property(e => e.MainDimensionid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$dimensionid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Fulldatamummy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fulldatamummies");

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(200)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(200)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(200)
                    .HasColumnName("area");

                entity.Property(e => e.Burialid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasMaxLength(5)
                    .HasColumnName("burialmaterials");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.CariesPeriodontalDisease)
                    .HasMaxLength(255)
                    .HasColumnName("Caries_Periodontal_Disease");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(200)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Color).HasColumnType("text");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(200)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.DateofExamination).HasMaxLength(255);

                entity.Property(e => e.Dateofexcavation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasMaxLength(200)
                    .HasColumnName("depth");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Direction)
                    .HasMaxLength(200)
                    .HasColumnName("direction");

                entity.Property(e => e.DorsalPittingBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("DorsalPitting (boolean)");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(200)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Estimatedperiod)
                    .HasMaxLength(200)
                    .HasColumnName("estimatedperiod");

                entity.Property(e => e.Excavationrecorder)
                    .HasMaxLength(100)
                    .HasColumnName("excavationrecorder");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(200)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Femur).HasMaxLength(255);

                entity.Property(e => e.FemurHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Gonion).HasMaxLength(255);

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .HasColumnName("goods");

                entity.Property(e => e.Hair)
                    .HasMaxLength(5)
                    .HasColumnName("hair");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(200)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(200)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Humerus).HasMaxLength(255);

                entity.Property(e => e.HumerusHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.LamboidSuture).HasMaxLength(255);

                entity.Property(e => e.LeftRightBurialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Left_Right_BurialNumber");

                entity.Property(e => e.LeftRightId).HasColumnName("Left_Right_id");

                entity.Property(e => e.Length)
                    .HasMaxLength(200)
                    .HasColumnName("length");

                entity.Property(e => e.Locale)
                    .HasMaxLength(200)
                    .HasColumnName("locale");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");

                entity.Property(e => e.MedialIpRamus)
                    .HasMaxLength(255)
                    .HasColumnName("Medial_IP_Ramus");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(200)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Notes).HasMaxLength(859);

                entity.Property(e => e.NuchalCrest).HasMaxLength(255);

                entity.Property(e => e.Observations).HasMaxLength(830);

                entity.Property(e => e.OrbitEdge).HasMaxLength(255);

                entity.Property(e => e.Osteophytosis).HasMaxLength(255);

                entity.Property(e => e.ParietalBossing).HasMaxLength(255);

                entity.Property(e => e.Photographeddate)
                    .HasColumnType("datetime")
                    .HasColumnName("photographeddate");

                entity.Property(e => e.Photos)
                    .HasMaxLength(5)
                    .HasColumnName("photos");

                entity.Property(e => e.PreauricularSulcusBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("PreauricularSulcus (Boolean)");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(200)
                    .HasColumnName("preservation");

                entity.Property(e => e.PubicBone).HasMaxLength(255);

                entity.Property(e => e.RightArea)
                    .HasMaxLength(255)
                    .HasColumnName("Right_Area");

                entity.Property(e => e.RightBurialnumber)
                    .HasMaxLength(255)
                    .HasColumnName("Right_burialnumber");

                entity.Property(e => e.RightEastWest)
                    .HasMaxLength(255)
                    .HasColumnName("Right_EastWest");

                entity.Property(e => e.RightHairColor)
                    .HasMaxLength(255)
                    .HasColumnName("Right_HairColor");

                entity.Property(e => e.RightId).HasColumnName("Right_id");

                entity.Property(e => e.RightNorthSouth)
                    .HasMaxLength(255)
                    .HasColumnName("Right_NorthSouth");

                entity.Property(e => e.RightSquareEastWest).HasColumnName("Right_SquareEastWest");

                entity.Property(e => e.RightSquareNorthSouth).HasColumnName("Right_SquareNorthSouth");

                entity.Property(e => e.Robust).HasMaxLength(255);

                entity.Property(e => e.Sampledate)
                    .HasColumnType("datetime")
                    .HasColumnName("sampledate");

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(200)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.SciaticNotch).HasMaxLength(255);

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .HasColumnName("sex");

                entity.Property(e => e.Shaftnumber)
                    .HasMaxLength(200)
                    .HasColumnName("shaftnumber");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(200)
                    .HasColumnName("southtohead");

                entity.Property(e => e.SphenooccipitalSynchrondrosis).HasMaxLength(255);

                entity.Property(e => e.SquamosSuture).HasMaxLength(255);

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(200)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(200)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.SubpubicAngle).HasMaxLength(255);

                entity.Property(e => e.SupraorbitalRidges).HasMaxLength(255);

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.TextileFunction).HasMaxLength(200);

                entity.Property(e => e.TextileStructure).HasColumnType("text");

                entity.Property(e => e.ToothAttrition).HasMaxLength(255);

                entity.Property(e => e.ToothEruption).HasMaxLength(255);

                entity.Property(e => e.ToothEruptionAgeEstimate).HasMaxLength(255);

                entity.Property(e => e.VentralArc).HasMaxLength(255);

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(200)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(200)
                    .HasColumnName("wrapping");

                entity.Property(e => e.ZygomaticCrest).HasMaxLength(255);
            });

            modelBuilder.Entity<Newsarticle>(entity =>
            {
                entity.ToTable("newsarticle");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .HasColumnName("author");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url");

                entity.Property(e => e.Urltoimage)
                    .HasMaxLength(255)
                    .HasColumnName("urltoimage");
            });

            modelBuilder.Entity<PhotodataTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainPhotodataid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("photodata_textile");

                entity.Property(e => e.MainPhotodataid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$photodataid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Photodatum>(entity =>
            {
                entity.ToTable("photodata");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Filename)
                    .HasMaxLength(200)
                    .HasColumnName("filename");

                entity.Property(e => e.Photodataid)
                    .HasColumnType("int(11)")
                    .HasColumnName("photodataid");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Photoform>(entity =>
            {
                entity.ToTable("photoform");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .HasColumnName("area");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(10)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(1)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Filename)
                    .HasMaxLength(200)
                    .HasColumnName("filename");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(1)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Photodate)
                    .HasColumnType("timestamp")
                    .HasColumnName("photodate");

                entity.Property(e => e.Photographer)
                    .HasMaxLength(100)
                    .HasColumnName("photographer");

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(100)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(5)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.Tableassociation)
                    .HasMaxLength(10)
                    .HasColumnName("tableassociation");
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.ToTable("structure");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Structureid)
                    .HasColumnType("int(11)")
                    .HasColumnName("structureid");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<StructureTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainStructureid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("structure_textile");

                entity.Property(e => e.MainStructureid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$structureid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Teammember>(entity =>
            {
                entity.ToTable("teammember");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Bio)
                    .HasMaxLength(255)
                    .HasColumnName("bio");

                entity.Property(e => e.Membername)
                    .HasMaxLength(200)
                    .HasColumnName("membername");
            });

            modelBuilder.Entity<Testingstuff>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("testingstuff");

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(255)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(255)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(255)
                    .HasColumnName("area");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(255)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(255)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ColorValue)
                    .HasMaxLength(255)
                    .HasColumnName("color_value");

                entity.Property(e => e.Colorid1).HasColumnName("colorid");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(255)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.Depth)
                    .HasMaxLength(255)
                    .HasColumnName("depth");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(255)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(255)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(255)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(255)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Goods)
                    .HasMaxLength(255)
                    .HasColumnName("goods");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(255)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(255)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Length)
                    .HasMaxLength(255)
                    .HasColumnName("length");

                entity.Property(e => e.Locale)
                    .HasMaxLength(255)
                    .HasColumnName("locale");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(255)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Photographeddate)
                    .HasColumnType("datetime")
                    .HasColumnName("photographeddate");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(255)
                    .HasColumnName("preservation");

                entity.Property(e => e.RecordId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("RecordID");

                entity.Property(e => e.Sampledate)
                    .HasColumnType("datetime")
                    .HasColumnName("sampledate");

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(255)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.Sex)
                    .HasMaxLength(255)
                    .HasColumnName("sex");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(255)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(255)
                    .HasColumnName("southtohead");

                entity.Property(e => e.Squareeastwest).HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth).HasColumnName("squarenorthsouth");

                entity.Property(e => e.StructureId).HasColumnName("structure_id");

                entity.Property(e => e.StructureValue)
                    .HasMaxLength(255)
                    .HasColumnName("structure_value");

                entity.Property(e => e.Structureid1).HasColumnName("structureid");

                entity.Property(e => e.Text)
                    .HasMaxLength(678)
                    .HasColumnName("text");

                entity.Property(e => e.TextileBurialnumber)
                    .HasMaxLength(255)
                    .HasColumnName("textile_burialnumber");

                entity.Property(e => e.TextileId).HasColumnName("textile_id");

                entity.Property(e => e.TextilefunctionId).HasColumnName("textilefunction_id");

                entity.Property(e => e.TextilefunctionValue)
                    .HasMaxLength(255)
                    .HasColumnName("textilefunction_value");

                entity.Property(e => e.Textilefunctionid1).HasColumnName("textilefunctionid");

                entity.Property(e => e.Textileid1).HasColumnName("textileid");

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(255)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(255)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(255)
                    .HasColumnName("wrapping");
            });

            modelBuilder.Entity<Textile>(entity =>
            {
                entity.ToTable("textile");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Direction)
                    .HasMaxLength(200)
                    .HasColumnName("direction");

                entity.Property(e => e.Estimatedperiod)
                    .HasMaxLength(200)
                    .HasColumnName("estimatedperiod");

                entity.Property(e => e.Locale)
                    .HasMaxLength(200)
                    .HasColumnName("locale");

                entity.Property(e => e.Photographeddate)
                    .HasColumnType("timestamp")
                    .HasColumnName("photographeddate");

                entity.Property(e => e.Sampledate)
                    .HasColumnType("timestamp")
                    .HasColumnName("sampledate");

                entity.Property(e => e.Textileid)
                    .HasColumnType("int(11)")
                    .HasColumnName("textileid");
            });

            modelBuilder.Entity<Textiledetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("textiledetails");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.Color).HasColumnType("text");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Direction)
                    .HasMaxLength(200)
                    .HasColumnName("direction");

                entity.Property(e => e.Estimatedperiod)
                    .HasMaxLength(200)
                    .HasColumnName("estimatedperiod");

                entity.Property(e => e.Locale)
                    .HasMaxLength(200)
                    .HasColumnName("locale");

                entity.Property(e => e.MainBurialmainid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$burialmainid");

                entity.Property(e => e.Photographeddate)
                    .HasColumnType("datetime")
                    .HasColumnName("photographeddate");

                entity.Property(e => e.Sampledate)
                    .HasColumnType("datetime")
                    .HasColumnName("sampledate");

                entity.Property(e => e.TextileFunction).HasMaxLength(200);

                entity.Property(e => e.TextileStructure).HasColumnType("text");
            });

            modelBuilder.Entity<Textilefunction>(entity =>
            {
                entity.ToTable("textilefunction");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Textilefunctionid)
                    .HasColumnType("int(11)")
                    .HasColumnName("textilefunctionid");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<TextilefunctionTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainTextilefunctionid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("textilefunction_textile");

                entity.Property(e => e.MainTextilefunctionid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textilefunctionid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Websitetable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("websitetable");

                entity.Property(e => e.Adultsubadult)
                    .HasMaxLength(200)
                    .HasColumnName("adultsubadult");

                entity.Property(e => e.Ageatdeath)
                    .HasMaxLength(200)
                    .HasColumnName("ageatdeath");

                entity.Property(e => e.Area)
                    .HasMaxLength(200)
                    .HasColumnName("area");

                entity.Property(e => e.Burialid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasMaxLength(5)
                    .HasColumnName("burialmaterials");

                entity.Property(e => e.Burialnumber)
                    .HasMaxLength(200)
                    .HasColumnName("burialnumber");

                entity.Property(e => e.CariesPeriodontalDisease)
                    .HasMaxLength(255)
                    .HasColumnName("Caries_Periodontal_Disease");

                entity.Property(e => e.Clusternumber)
                    .HasMaxLength(200)
                    .HasColumnName("clusternumber");

                entity.Property(e => e.Color).HasColumnType("text");

                entity.Property(e => e.Dataexpertinitials)
                    .HasMaxLength(200)
                    .HasColumnName("dataexpertinitials");

                entity.Property(e => e.DateofExamination).HasMaxLength(255);

                entity.Property(e => e.Dateofexcavation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasMaxLength(200)
                    .HasColumnName("depth");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Direction)
                    .HasMaxLength(200)
                    .HasColumnName("direction");

                entity.Property(e => e.DorsalPittingBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("DorsalPitting (boolean)");

                entity.Property(e => e.Eastwest)
                    .HasMaxLength(200)
                    .HasColumnName("eastwest");

                entity.Property(e => e.Estimatedperiod)
                    .HasMaxLength(200)
                    .HasColumnName("estimatedperiod");

                entity.Property(e => e.Excavationrecorder)
                    .HasMaxLength(100)
                    .HasColumnName("excavationrecorder");

                entity.Property(e => e.Facebundles)
                    .HasMaxLength(200)
                    .HasColumnName("facebundles");

                entity.Property(e => e.Femur).HasMaxLength(255);

                entity.Property(e => e.FemurHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookexcavationyear");

                entity.Property(e => e.Fieldbookpage)
                    .HasMaxLength(200)
                    .HasColumnName("fieldbookpage");

                entity.Property(e => e.Gonion).HasMaxLength(255);

                entity.Property(e => e.Goods)
                    .HasMaxLength(200)
                    .HasColumnName("goods");

                entity.Property(e => e.Hair)
                    .HasMaxLength(5)
                    .HasColumnName("hair");

                entity.Property(e => e.Haircolor)
                    .HasMaxLength(200)
                    .HasColumnName("haircolor");

                entity.Property(e => e.Headdirection)
                    .HasMaxLength(200)
                    .HasColumnName("headdirection");

                entity.Property(e => e.Humerus).HasMaxLength(255);

                entity.Property(e => e.HumerusHeadDiameter).HasMaxLength(255);

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.LamboidSuture).HasMaxLength(255);

                entity.Property(e => e.Length)
                    .HasMaxLength(200)
                    .HasColumnName("length");

                entity.Property(e => e.Locale)
                    .HasMaxLength(200)
                    .HasColumnName("locale");

                entity.Property(e => e.MedialIpRamus)
                    .HasMaxLength(255)
                    .HasColumnName("Medial_IP_Ramus");

                entity.Property(e => e.Northsouth)
                    .HasMaxLength(200)
                    .HasColumnName("northsouth");

                entity.Property(e => e.Notes).HasMaxLength(859);

                entity.Property(e => e.NuchalCrest).HasMaxLength(255);

                entity.Property(e => e.Observations).HasMaxLength(830);

                entity.Property(e => e.OrbitEdge).HasMaxLength(255);

                entity.Property(e => e.Osteophytosis).HasMaxLength(255);

                entity.Property(e => e.ParietalBossing).HasMaxLength(255);

                entity.Property(e => e.Photographeddate)
                    .HasColumnType("datetime")
                    .HasColumnName("photographeddate");

                entity.Property(e => e.Photos)
                    .HasMaxLength(5)
                    .HasColumnName("photos");

                entity.Property(e => e.PreauricularSulcusBoolean)
                    .HasMaxLength(255)
                    .HasColumnName("PreauricularSulcus (Boolean)");

                entity.Property(e => e.Preservation)
                    .HasMaxLength(200)
                    .HasColumnName("preservation");

                entity.Property(e => e.PubicBone).HasMaxLength(255);

                entity.Property(e => e.RightBurialnumber)
                    .HasMaxLength(255)
                    .HasColumnName("Right_burialnumber");

                entity.Property(e => e.RightHairColor)
                    .HasMaxLength(255)
                    .HasColumnName("Right_HairColor");

                entity.Property(e => e.Robust).HasMaxLength(255);

                entity.Property(e => e.Sampledate)
                    .HasColumnType("datetime")
                    .HasColumnName("sampledate");

                entity.Property(e => e.Samplescollected)
                    .HasMaxLength(200)
                    .HasColumnName("samplescollected");

                entity.Property(e => e.SciaticNotch).HasMaxLength(255);

                entity.Property(e => e.Sex)
                    .HasMaxLength(200)
                    .HasColumnName("sex");

                entity.Property(e => e.Shaftnumber)
                    .HasMaxLength(200)
                    .HasColumnName("shaftnumber");

                entity.Property(e => e.Southtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("southtofeet");

                entity.Property(e => e.Southtohead)
                    .HasMaxLength(200)
                    .HasColumnName("southtohead");

                entity.Property(e => e.SphenooccipitalSynchrondrosis).HasMaxLength(255);

                entity.Property(e => e.SquamosSuture).HasMaxLength(255);

                entity.Property(e => e.Squareeastwest)
                    .HasMaxLength(200)
                    .HasColumnName("squareeastwest");

                entity.Property(e => e.Squarenorthsouth)
                    .HasMaxLength(200)
                    .HasColumnName("squarenorthsouth");

                entity.Property(e => e.SubpubicAngle).HasMaxLength(255);

                entity.Property(e => e.SupraorbitalRidges).HasMaxLength(255);

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.TextileFunction).HasMaxLength(200);

                entity.Property(e => e.TextileStructure).HasColumnType("text");

                entity.Property(e => e.ToothAttrition).HasMaxLength(255);

                entity.Property(e => e.ToothEruption).HasMaxLength(255);

                entity.Property(e => e.ToothEruptionAgeEstimate).HasMaxLength(255);

                entity.Property(e => e.VentralArc).HasMaxLength(255);

                entity.Property(e => e.Westtofeet)
                    .HasMaxLength(200)
                    .HasColumnName("westtofeet");

                entity.Property(e => e.Westtohead)
                    .HasMaxLength(200)
                    .HasColumnName("westtohead");

                entity.Property(e => e.Wrapping)
                    .HasMaxLength(200)
                    .HasColumnName("wrapping");

                entity.Property(e => e.ZygomaticCrest).HasMaxLength(255);
            });

            modelBuilder.Entity<Yarnmanipulation>(entity =>
            {
                entity.ToTable("yarnmanipulation");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Angle)
                    .HasMaxLength(20)
                    .HasColumnName("angle");

                entity.Property(e => e.Component)
                    .HasMaxLength(200)
                    .HasColumnName("component");

                entity.Property(e => e.Count)
                    .HasMaxLength(100)
                    .HasColumnName("count");

                entity.Property(e => e.Direction)
                    .HasMaxLength(20)
                    .HasColumnName("direction");

                entity.Property(e => e.Manipulation)
                    .HasMaxLength(100)
                    .HasColumnName("manipulation");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .HasColumnName("material");

                entity.Property(e => e.Ply)
                    .HasMaxLength(20)
                    .HasColumnName("ply");

                entity.Property(e => e.Thickness)
                    .HasMaxLength(20)
                    .HasColumnName("thickness");

                entity.Property(e => e.Yarnmanipulationid)
                    .HasColumnType("int(11)")
                    .HasColumnName("yarnmanipulationid");
            });

            modelBuilder.Entity<YarnmanipulationTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainYarnmanipulationid, e.MainTextileid })
                    .HasName("PRIMARY");

                entity.ToTable("yarnmanipulation_textile");

                entity.Property(e => e.MainYarnmanipulationid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$yarnmanipulationid");

                entity.Property(e => e.MainTextileid)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("main$textileid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
