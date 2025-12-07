using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesRecorded;

        public EternalGoal(string name, string description, int points, int timesRecorded = 0)
            : base(name, description, points)
        {
            _timesRecorded = timesRecorded;
        }

        public override int RecordEvent()
        {
            _timesRecorded++;
            return _points;
        }

        public override bool IsComplete() => false; 

        public override string Serialize()
        {
            return $"Eternal|{_name}|{_description}|{_points}|{_timesRecorded}";
        }

        public override string GetStatusString()
        {
            return $"[X] (Eternal) - Recorded {_timesRecorded} times";
        }

        public override string ExtraInfo() => $"Recorded: {_timesRecorded}";
    }
}
