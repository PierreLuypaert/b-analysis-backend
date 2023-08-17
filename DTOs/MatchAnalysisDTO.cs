namespace B_Analysis_BackEnd.DTOs;

public class MatchAnalysisDTO
{
    public List<List<float>> BallPosition { get; set; }
    public List<float> BallSpeed { get; set; }
    public List<List<float>> BabyDelimitation { get; set; }
    public int MatchDuration { get; set; }
    public List<List<float>> PredictedGoals { get; set; }
}