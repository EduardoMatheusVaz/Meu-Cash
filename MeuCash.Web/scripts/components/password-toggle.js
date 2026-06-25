const senha = document.getElementById("senha");
const botao = document.getElementById("btnMostrarSenha");

botao.addEventListener("click", () => {
    senha.type = senha.type === "password" ? "text" : "password";
});
