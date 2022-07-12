using System;
using System.Linq;
using System.Runtime.InteropServices;
using Infra.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

namespace FunctionEnvioEmail.Dominio
{
    public class LeituraFilaEmail : IDisposable
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public LeituraFilaEmail()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public void EnvioEmails()
        {
            var dadosEmail = new DadosEmail();

            using (var dataBase = new ContextBase(_optionsBuilder))
            {
                var encontrouEmail = false;

                var listaSolicitacoes = dataBase.Set<SolicitacaoEmail>()
                    .Where(s => !s.Enviado).AsNoTracking().ToList();

                foreach (var solicitacao in listaSolicitacoes)
                {
                    try
                    {
                        dadosEmail.EnviarEmail(solicitacao.Titulo,
                                                solicitacao.Mensagem,
                                                solicitacao.Destinatarios);
                        solicitacao.Enviado = true;

                        dataBase.SolicitacaoEmail.Update(solicitacao);
                        dataBase.SaveChanges();

                        encontrouEmail = true;

                    }
                    catch (Exception ex)
                    {

                    }
                }

                if (encontrouEmail)
                {
                    var listaSolicitacoesDeletar = dataBase.Set<SolicitacaoEmail>()
                   .Where(s => s.Enviado).AsNoTracking().ToList();
                    if (listaSolicitacoes.Any())
                    {
                        dataBase.SolicitacaoEmail.RemoveRange(listaSolicitacoesDeletar);
                        dataBase.SaveChanges();
                    }
                }
            }
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }
    }
}
