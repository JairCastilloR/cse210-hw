using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, string description, int points, bool completed = false)
            : base(name, description, points)
        {
            _completed = completed;
        }

        public override int RecordEvent()
        {
            if (_completed) return 0;
            _completed = true;
            return _points;
        }

        public override bool IsComplete() => _completed;

        public override string Serialize()
        {
            return $"Simple|{_name}|{_description}|{_points}|{_completed}";
        }

        public override string GetStatusString()
        {
            return _completed ? "[X] (Simple)" : "[ ] (Simple)";
        }
    }
}
