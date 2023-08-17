using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace B_Analysis_BackEnd.Models;

public class Match
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? Date { get; set; }
    public Player? RedDefender { get; set; }
    public Player? RedAttacker { get; set; }
    public Player? BlueDefender { get; set; }
    public Player? BlueAttacker { get; set; }
    public int? MatchDuration { get; set; }
    public string? BallPositionSerialized { get; set; }
    public string? BallSpeedSerialized { get; set; }
    
    //public int FrameRate { get; set; }
    //public string PredictedGoalsSerialized { get; set; }
    
    public string VideoUrl { get; set; }
    public int scoreRed { get; set; }
    public int scoreBlue { get; set; }
    

    [NotMapped]
    public List<List<float>>? BallPosition
    {
        get
        {
            if (BallPositionSerialized == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<List<float>>>(BallPositionSerialized);
        }
        set
        {
            BallPositionSerialized = JsonConvert.SerializeObject(value);
        }
    }

    [NotMapped]
    public List<float>? BallSpeed
    {
        get
        {
            if (BallSpeedSerialized == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<float>>(BallSpeedSerialized);
        }
        set
        {
            BallSpeedSerialized = JsonConvert.SerializeObject(value);
        }
    }
    
    

    /*[NotMapped]
    public List<List<float>>? PredictedGoals
    {
        get
        {
            if (PredictedGoalsSerialized == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<List<float>>>(PredictedGoalsSerialized);
        }
        set
        {
            PredictedGoalsSerialized = JsonConvert.SerializeObject(value);
        }
    }*/
}