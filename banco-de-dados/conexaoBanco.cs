using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class conexaoBanco : MonoBehaviour
{
    private string chaveSecreta = "titanic-each-usp"; // Troque este valor e lembre-se de colocar o mesmo no servidor
    public string salvarPontuacaoURL = "http://lapis.each.usp.br/seuprojeto/salvarPontuacao.php?"; // é necessário ter o "?" após a URL
    public string recuperarPontuacaoURL = "http://lapis.each.usp.br/seuprojeto/recuperarPontuacao.php?"; // é necessário ter o "?" após a URL
    public Text mensagem;

    void Start(){
        StartCoroutine(recuperarPontuacao()); // na chamada destas funções, sempre utilizar StartCoroutine
    }
    
    IEnumerator salvarPontuacao(string nome, int pontos){

        string hash = MD5Test.Md5Sum(nome + pontos + secretKey);

        string caminho = salvarPontuacaoURL + "nome=" + WWW.EscapeURL(nome) + "&pontos=" + pontos + "&hash=" + hash;
        WWW conexao = new WWW(caminho);
        yield return conexao; 

        if (conexao.error != null){
            print("Não foi possível salvar a pontuação: " + conexao.error); // exibe o erro no console
        }
    }

    /* RECUPERAÇÃO DE DADOS DO BANCO */

    IEnumerator recuperarPontuacao(string nome){

        mensagem.text = "Carregando pontuação...";

        string caminho = recuperarPontuacaoURL + "nome=" + WWW.EscapeURL(nome);
        WWW conexao = new WWW(caminho);
        yield return conexao;

        if(conexao.error != null){
            print("Não foi possível recuperar a pontuação: " + conexao.error); // exibe o erro no console
        }
        else{
            mensagem.text = conexao.text; // elemento de texto exibe a pontuação.
        }
  }

}
