/***
 * 
 * Componente: CDSImprimeTexto
 *		  Autor: Carlos dos Santos
 *		   Data: 21/07/2004
 *      Revisão: 25/04/2011 (este revisão modifica o acesso a porta da impressora, permitindo que o componente funcione no Windows Vista e Windows 7.
 *   Objetivo: Imprime texto diretamente na porta da impressora.
 * 
 ***/
using System;
using System.Runtime.InteropServices;
using System.IO;

namespace CDSSoftware
{
	class PortaException : System.Exception {};
  
	/// <summary>
	/// Classe para impressão de textos diretamente para a porta da impressora.
	/// © 2004 CDS Informática Ltda.
	/// </summary>
	public class ImprimeTexto
	{

		private int GENERIC_WRITE = 0x40000000;
		private int OPEN_EXISTING = 3;
		private int FILE_SHARE_WRITE = 0x2;
		private string sPorta;
		private int hPort;
		private FileStream outFile;
		private StreamWriter fileWriter;
		private IntPtr hPortP;
		private bool lOK = false;
        private string GeraArquivoLPT;

		private string Chr(int asc)
		{
			string ret = "";
			ret += (char)asc;
			return ret;
		}

		[DllImport("kernel32.dll",EntryPoint="CreateFileA")]
		static extern int CreateFileA(string lpFileName,int dwDesiredAccess, int dwShareMode,
			int lpSecurityAttributes,
			int dwCreationDisposition, int dwFlagsAndAttributes,
			int hTemplateFile);

		[DllImport("kernel32.dll",EntryPoint="CloseHandle")]
		static extern int CloseHandle(int hObject);

		/// <summary>
		/// Configura a impressora para impressão normal.
		/// </summary>
		public string Normal
		{
			get 
			{
					return Chr(18);
			}
		}

		/// <summary>
		/// Configura a impressora para impressão em modo condensado.
		/// </summary>
		public string Comprimido
		{
			get 
			{
				return Chr(15);
			}
		}

		/// <summary>
		/// Configura a impressora para impressão em modo expandido.
		/// </summary>
		public string Expandido
		{
			get 
			{
				return Chr(14);
			}
		}

		/// <summary>
		/// Configura a impressora para impressão em modo expandido normal.
		/// </summary>
		public string ExpandidoNormal
		{
			get 
			{
				return Chr(20);
			}
		}


		/// <summary>
		/// Ativa o modo negrito da impressora.
		/// </summary>
		public string NegritoOn
		{
			get 
			{
				return Chr(27)+Chr(69);
			}
		}


		/// <summary>
		/// Desativa o modo negrito da impressora.
		/// </summary>
		public string NegritoOff
		{
			get 
			{
				return Chr(27)+Chr(70);
			}
		}

		
		/// <summary>
		/// Inicia a impressão em modo texto.
		/// </summary>
		/// <param name="sPortaInicio">Especifica a porta da impressora (LPT1,LPT2,LPT3,LPT4,...)</param>
		/// <returns>Retorna true se inciar a impressora e false caso contrário</returns>
		public bool Inicio(string sPortaInicio)
		{
            GeraArquivoLPT = "";
			sPortaInicio.ToUpper();
            outFile = null;
            if (sPortaInicio.Substring(0, 3) == "LPT")
            {
                if (sPortaInicio == "LPT")
                {
                    sPortaInicio = "LPT1";
                }
                sPorta = sPortaInicio;
                sPortaInicio = "LPT-" + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + ".TXT";
                GeraArquivoLPT = sPortaInicio;
                fileWriter = new StreamWriter(sPortaInicio);
                lOK = true;
                //hPort = CreateFileA(sPorta, GENERIC_WRITE, FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
                //if (hPort != -1)
                //{
                //    hPortP = new IntPtr(hPort);
                //    outFile = new FileStream(hPortP, FileAccess.Write);
                //    fileWriter = new StreamWriter(outFile);
                //    lOK = true;
                //}
                //else
                //{
                //    lOK = false;
                //}
            }
            else
            {
                fileWriter = new StreamWriter(sPortaInicio);
                lOK = true;
            }
			return lOK;
		}

		/// <summary>
		/// Finaliza a Impressao.
		/// </summary>
		public void Fim()
		{
			if(lOK)
			{
				fileWriter.Close();
                if (outFile != null)
                {
                    outFile.Close();
                    CloseHandle(hPort);
                }
				lOK = false;

                if (GeraArquivoLPT != String.Empty)
                {
                    System.IO.File.Copy(GeraArquivoLPT, sPorta);
                    File.Delete(GeraArquivoLPT);
                    GeraArquivoLPT = "";
                }
			}
		}

		/// <summary>
		/// Imprime uma string.
		/// </summary>
		/// <param name="sLinha">String a ser impressa</param>
		public void Imp(string sLinha)
		{
			if(lOK) 
			{
				fileWriter.Write(sLinha);
				fileWriter.Flush();
			}
		}  
		
		/// <summary>
		/// Imprime uma string e pula uma linha.
		/// </summary>
		/// <param name="sLinha">String a ser impressa</param>
		public void ImpLF(string sLinha)
		{
			if(lOK)
			{
				fileWriter.WriteLine(sLinha);
				fileWriter.Flush();
			}
		}  

		/// <summary>
		/// Imprime uma string em uma determinada coluna.
		/// </summary>
		/// <param name="nCol">Coluna a ser posicionada</param>
		/// <param name="sLinha">String a ser impressa</param>
		public void ImpCol(int nCol, string sLinha)
		{
            string Cols = "";
            Cols = Cols.PadLeft(nCol, ' ');
            Imp(Chr(13)+ Cols + sLinha);
		}
	
    /// <summary>
    /// Imprime uma string em uma determinada coluna e pula uma linha.
    /// </summary>
    /// <param name="nCol">Coluna a ser posicionada</param>
    /// <param name="sLinha">String a ser impressa</param>
		public void ImpColLF(int nCol, string sLinha)
		{
            ImpCol(nCol, sLinha);
            Pula(1);
		}

		/// <summary>
		/// Pula uma numero determinado de linhas.
		/// </summary>
		/// <param name="nLinha">Número de linhas a serem puladas</param>
		public void Pula(int nLinha)
		{
			for(int i=0;i<nLinha;i++)
			{
				ImpLF("");
			}
	  }

		/// <summary>
		/// Ejeta uma página.
		/// </summary>
		public void Eject()
		{
			Imp(Chr(12));
		}

		public ImprimeTexto()
		{
			sPorta = "LPT1";
		}


	}
}
