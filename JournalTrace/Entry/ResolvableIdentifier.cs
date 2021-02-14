using JournalTrace.Native;
using System;

namespace JournalTrace.Entry
{
    public class ResolvableIdentifier
    {
        public ulong ID { get; set; }

        private string resolvedID;
        public string ResolvedID { get { return resolvedID == null ? ID.ToString() : resolvedID; } set { resolvedID = value; } }

        public ResolvableIdentifier(ulong iD)
        {
            ID = iD;
        }

        public void Resolve()
        {
            try
            {
                //cada id escrito no journal é referente a algum arquivo real no sistema
                //com a api, pegamos (se possivel) a entrada de cada diretorio
                //se a entrada não existir mais, colocamos soemnte o id
                string idPath = FileID.GetFilePath((long)ID);
                if (string.IsNullOrWhiteSpace(idPath))
                {
                    resolvedID = null;
                }
                else
                {
                    //o diretorio da api vem com 4 caracteres iniciais que não servem para nos
                    resolvedID = idPath.Remove(0, 4);
                }
            }
            catch (Exception)
            {
                resolvedID = null;
            }
        }
    }
}