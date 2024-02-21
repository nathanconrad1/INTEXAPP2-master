using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INTEXAPP2.Models
{
    public partial class Burialdetail
    {
        [Key]
        [Required]
        public long? Id { get; set; }
        public string? Squarenorthsouth { get; set; }
        public string? Headdirection { get; set; }
        public string? Sex { get; set; }
        public string? Northsouth { get; set; }
        public string? Depth { get; set; }
        public string? Eastwest { get; set; }
        public string? Adultsubadult { get; set; }
        public string? Facebundles { get; set; }
        public string? Southtohead { get; set; }
        public string? Preservation { get; set; }
        public string? Fieldbookpage { get; set; }
        public string? Squareeastwest { get; set; }
        public string? Goods { get; set; }
        public string? Text { get; set; }
        public string? Wrapping { get; set; }
        public string? Haircolor { get; set; }
        public string? Westtohead { get; set; }
        public string? Samplescollected { get; set; }
        public string? Area { get; set; }
        public long? Burialid { get; set; }
        public string? Length { get; set; }
        public string? Burialnumber { get; set; }
        public string? Dataexpertinitials { get; set; }
        public string? Westtofeet { get; set; }
        public string? Ageatdeath { get; set; }
        public string? Southtofeet { get; set; }
        public string? Excavationrecorder { get; set; }
        public string? Photos { get; set; }
        public string? Hair { get; set; }
        public string? Burialmaterials { get; set; }
        public DateTime? Dateofexcavation { get; set; }
        public string? Fieldbookexcavationyear { get; set; }
        public string? Clusternumber { get; set; }
        public string? Shaftnumber { get; set; }
        public double? RightId { get; set; }
        public double? RightSquareNorthSouth { get; set; }
        public string? RightNorthSouth { get; set; }
        public double? RightSquareEastWest { get; set; }
        public string? RightEastWest { get; set; }
        public string? RightArea { get; set; }
        public string? RightBurialNumber { get; set; }
        public string? DateofExamination { get; set; }
        public double? PreservationIndex { get; set; }
        public string? RightHairColor { get; set; }
        public string? Observations { get; set; }
        public string? Robust { get; set; }
        public string? SupraorbitalRidges { get; set; }
        public string? OrbitEdge { get; set; }
        public string? ParietalBossing { get; set; }
        public string? Gonion { get; set; }
        public string? NuchalCrest { get; set; }
        public string? ZygomaticCrest { get; set; }
        public string? SphenooccipitalSynchrondrosis { get; set; }
        public string? LamboidSuture { get; set; }
        public string? SquamosSuture { get; set; }
        public string? ToothAttrition { get; set; }
        public string? ToothEruption { get; set; }
        public string? ToothEruptionAgeEstimate { get; set; }
        public string? VentralArc { get; set; }
        public string? SubpubicAngle { get; set; }
        public string? SciaticNotch { get; set; }
        public string? PubicBone { get; set; }
        public string? PreauricularSulcusBoolean { get; set; }
        public string? MedialIpRamus { get; set; }
        public string? DorsalPittingBoolean { get; set; }
        public string? Femur { get; set; }
        public string? Humerus { get; set; }
        public string? FemurHeadDiameter { get; set; }
        public string? HumerusHeadDiameter { get; set; }
        public double? FemurLength { get; set; }
        public double? HumerusLength { get; set; }
        public double? EstimateStature { get; set; }
        public string? Osteophytosis { get; set; }
        public string? CariesPeriodontalDisease { get; set; }
        public string? Notes { get; set; }
    }
}
