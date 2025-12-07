using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _requiredCount;
        private int _currentCount;
        private int _completionBonus;

        public ChecklistGoal(string name, string description, int pointsPer, int requiredCount, int completionBonus, int currentCount = 0)
            : base(name, description, pointsPer)
        {
            _requiredCount = requiredCount;
            _completionBonus = completionBonus;
            _currentCount = currentCount;
        }

        public override int RecordEvent()
        {
            if (IsComplete()) return 0;

            _currentCount++;

            if (_currentCount >= _requiredCount)
            {
                return _points + _completionBonus;
            }

            return _points;
        }

        public override bool IsComplete() => _currentCount >= _requiredCount;

        public override string Serialize()
        {
            return $"Checklist|{_name}|{_description}|{_points}|{_requiredCount}|{_completionBonus}|{_currentCount}";
        }

        public override string GetStatusString()
        {
            return IsComplete()
                ? $"[X] (Checklist) {_currentCount}/{_requiredCount}"
                : $"[ ] (Checklist) {_currentCount}/{_requiredCount}";
        }

        public override string ExtraInfo() => $"Progress: {_currentCount}/{_requiredCount}, Bonus: {_completionBonus}";
    }
}
