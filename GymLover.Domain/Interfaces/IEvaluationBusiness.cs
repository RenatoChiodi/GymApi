using GymLover.Domain.Entities;
using System.Collections.Generic;

namespace GymLover.Domain.Interfaces
{
    public interface IEvaluationBusiness
    {
        List<Evaluation> GetEvaluations();

        void EditEvaluation(Evaluation evaluation);

        Evaluation GetEvaluation(int Id);

        void InsertEvaluation(Evaluation evaluation);

        void DeleteEvaluation(Evaluation evaluation);
    }
}
