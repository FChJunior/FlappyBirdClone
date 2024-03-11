# FlappyBirdClone
 Esse repositorio foi criado para guardar o processo de produção do clone do Flappy Bird Clone.

Recriando o Flappy Bird
 
Recriar jogos existentes é uma prática educativa valiosa no desenvolvimento de jogos. Ela permite que os estudantes compreendam profundamente as mecânicas de jogo, design de interação e programação. Ao replicar um jogo, os alunos podem desvendar os desafios enfrentados pelos desenvolvedores originais e aplicar esses aprendizados em suas próprias criações.
Objetivos:
•	Entender as mecânicas fundamentais e o design de jogos através da análise e replicação.
•	Desenvolver habilidades de programação e resolução de problemas.
•	Apreciar a complexidade e os detalhes envolvidos no desenvolvimento de jogos.
Atividade com Flappy Bird: Flappy Bird é um exemplo perfeito para esta atividade devido à sua simplicidade e popularidade. Os alunos irão recriar este jogo, focando nos seguintes aspectos:
1.	Mecânicas de Jogo: Analisar como o jogador interage com o jogo e quais regras definem o sucesso ou o fracasso.
2.	Design de Níveis: Observar como os obstáculos são posicionados para criar um desafio progressivo.
3.	Feedback Visual e Sonoro: Examinar como o jogo comunica informações e feedback ao jogador.
4.	Otimização de Código: Entender a importância de um código limpo e eficiente para jogos com alto desempenho.
Processo:
•	Análise Crítica: Começar com uma sessão de jogo e discussão sobre o que torna Flappy Bird atraente e desafiador.
•	Planejamento de Desenvolvimento: Esboçar o projeto do jogo, incluindo todos os elementos visuais e de áudio.
•	Codificação: Programar o jogo em uma engine de escolha, implementando as mecânicas e design observados.
•	Iteração e Polimento: Refinar o jogo com base em testes e feedback, melhorando a jogabilidade e a experiência do usuário.
Conclusão: Ao final da atividade, os alunos terão uma réplica funcional do Flappy Bird e uma compreensão mais rica do processo de desenvolvimento de jogos. Eles também terão a oportunidade de refletir sobre como podem aplicar esses conceitos e técnicas em seus próprios projetos originais.
Importância: Esta atividade destaca a importância de aprender através da replicação, uma técnica que pode ser aplicada em várias disciplinas. No contexto do desenvolvimento de jogos, ela prepara os alunos para enfrentar desafios reais e inovações futuras na indústria.

	Nessa nota de aula iremos trabalhar o jogo Flappy Bird desde o começo do projeto até o polimento e exportação do jogo. Segue os tópicos que estudaremos nessa nota de aula:
1.	Iniciando o Projeto: Criando o projeto 2D, selecionando o nome o local de salvamento do projeto.
2.	Configurando o Projeto: Importado os Assets e criando as pastas e configurando os sprites que serão utilizados.
3.	Criando o Cenário: Adicionando um background e um ground com movimentação.
4.	Criando os Obstáculos: Adicionando os obstáculos, programando a movimentação e o Spawn.
5.	Criando o Personagem: Adicionando o personagem com física, animação e programação do input.
6.	Game Over: Criando o sistema de Game Over ao colidir com os obstáculos.
7.	Sistema de Pontuação: Pontuando quando o personagem passa dos obstáculos.
8.	HUD: Adicionando a Interface de Usuário para mostrar a pontuação.
9.	Menu: Adicionando um menu inicial e de game over.
10.	 Polimento: Melhorando os controles, refatorando códigos, adicionando dificuldade.
11.	 Exportando: PC e Android.
Antes de iniciamos o projeto, existe um repositório no GitHub com todo o passo a passo dessa aula: https://github.com/FChJunior/FlappyBirdClone. 
Iniciando o Projeto
	Abra o Unity Hub e crie um projeto 2D Core, escolha um diretório e de o nome de Flappy Bird Clone.
 
	Depois do projeto criado, teremos essa tela:
 
*Lembre-se de verificar se o Editor da Unity está conectado com o VS Code e se ele está com as extensões corretas:
Configurando o Projeto
	Depois do projeto criado, iremos configurar nossa área de trabalho para que possamos começar a trabalhar no projeto. Iremos adicionar novas janelas e criar as pastas necessárias para poder organizar melhor nosso projeto. 
	Para começarmos, iremos organizar o layout das janelas e adicionar as janelas Animation e Animator que se encontram em Window >>> Animation:
 
*Adicione também as janelas de Project Settings, Preferencias, Build Settings que usaremos mais tarde.
Depois das Janelas adicionadas, iremos organizar o layout. Lembre se que o jogo será exportado tanto para PC quando para Android e por isso iremos utilizar a resolução 16:9 landscape que é na horizontal. Depois de tudo adi
