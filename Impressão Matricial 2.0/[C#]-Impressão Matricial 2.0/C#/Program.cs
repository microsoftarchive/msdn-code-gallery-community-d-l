using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDSSoftware;


namespace ImprimeTexto2
{
    /// <summary>
    /// Este programa imprime na porta LPT1 e também, gera um arquivo EXEMPLO.TXT, mostrando duas maneiras de usar o componente.
    /// O componente pode ser usado livremente desde que o direito autoral seja mantido.
    /// Compatível com Framework 2.0, 3.0, 3.5 e 4.0.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ImprimeImpressora();
            ImprimeEmArquivo();
        }

        static public void ImprimeImpressora()
        {
            ImprimeTexto imp = new ImprimeTexto();

            imp.Inicio("LPT1");

            imp.ImpLF("Carlos dos Santos - MVP C#");
            imp.ImpLF("CDS Informática Ltda.");
            imp.ImpLF("-------------------------------------");
            imp.ImpLF("Componente de impressao em modo texto");
            for (int i = 0; i < 5; i++)
            {
                imp.ImpLF("Linha impressa " + i.ToString());
            }
            imp.ImpLF(imp.NegritoOn + "Negrito ligado" + imp.NegritoOff);
            imp.ImpLF(imp.Expandido + "Expandido" + imp.Normal);
            imp.ImpLF(imp.Comprimido + "Comprimido" + imp.Normal);
            imp.Pula(2);
            imp.ImpCol(10, "Coluna 10");
            imp.ImpCol(40, "Coluna 40");
            imp.Pula(2);
            imp.Imp((char)27 + "0");
            imp.ImpLF("8 linha ppp");
            imp.ImpLF("8 linha ppp");
            imp.ImpLF("8 linha ppp");
            imp.Imp((char)27 + "2");
            imp.ImpLF("6 linha ppp");
            imp.ImpLF("6 linha ppp");
            imp.ImpLF("6 linha ppp");
            imp.Pula(2);
            imp.Fim();
        }

        static public void ImprimeEmArquivo()
        {
            ImprimeTexto imp = new ImprimeTexto();

            imp.Inicio("exemplo.txt");

            imp.ImpLF("Carlos dos Santos - MVP C#");
            imp.ImpLF("CDS Informática Ltda.");
            imp.ImpLF("-------------------------------------");
            imp.ImpLF("Componente de impressao em modo texto");
            for (int i = 0; i < 5; i++)
            {
                imp.ImpLF("Linha impressa " + i.ToString());
            }
            imp.ImpLF(imp.NegritoOn + "Negrito ligado" + imp.NegritoOff);
            imp.ImpLF(imp.Expandido + "Expandido" + imp.Normal);
            imp.ImpLF(imp.Comprimido + "Comprimido" + imp.Normal);
            imp.Pula(2);
            imp.ImpCol(10, "Coluna 10");
            imp.ImpCol(40, "Coluna 40");
            imp.Pula(2);
            imp.Imp((char)27 + "0");
            imp.ImpLF("8 linha ppp");
            imp.ImpLF("8 linha ppp");
            imp.ImpLF("8 linha ppp");
            imp.Imp((char)27 + "2");
            imp.ImpLF("6 linha ppp");
            imp.ImpLF("6 linha ppp");
            imp.ImpLF("6 linha ppp");
            imp.Pula(2);
            imp.Fim();
        }


    }
}
