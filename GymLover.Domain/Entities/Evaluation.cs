using System;

namespace GymLover.Domain.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public float Peso { get; set; }
        public Circunferencia Circunferencia { get; set; }
        public ComposicaoCorporal ComposicaoCorporal { get; set; }
        public DobrasCutaneas DobrasCutaneas { get; set; }
    }

    public class Circunferencia
    {
        public int Id { get; set; }
        public float Pescoco { get; set; }
        public float Torax { get; set; }
        public float BracoDir { get; set; }
        public float BracoEsq { get; set; }
        public float AnteBracoDir { get; set; }
        public float AnteBracoEsq { get; set; }
        public float Cintura { get; set; }
        public float Abdomen { get; set; }
        public float Quadril { get; set; }
        public float CoxaDir { get; set; }
        public float CoxaEsq { get; set; }
        public float PernaDir { get; set; }
        public float PernaEsq { get; set; }

    }

    public class ComposicaoCorporal
    {
        public int Id { get; set; }
        public float GorduraAtual { get; set; }
        public float GorduraIdeal { get; set; }
        public float GorduraSobra { get; set; }
        public float PesoSobra { get; set; }
        public float MassaGordaTotal { get; set; }

    }

    public class DobrasCutaneas
    {
        public int Id { get; set; }
        public int Triceps { get; set; }
        public int Biceps { get; set; }
        public int Costas { get; set; }
        public int Peito { get; set; }
        public int Torax { get; set; }
        public int Iliaca { get; set; }
        public int Abdominal { get; set; }
        public int Coxa { get; set; }
        public int Panturrilha { get; set; }

    }
}
