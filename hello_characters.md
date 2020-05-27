# Hello World de Bonecos 
## Objetivo - aprender como usar bonecos na unity.
- Bonecos são uma parte fundamental de qualquer jogo. Até o momento só tenho usado cubos e outras formas geométricas primitivas.
1) Criei um cenário: Um GameObject chamado Scenario com um plano e quatro cubos esticados formando as paredes. Pus cor neles criando um material pro chão e outro pro cubo.
2) Tudo relativo a esse estudo estará no subdiretório Hello Characters.
3) Lembrar de adicionar a cena Hello Characters à lista de cenas da build para que o script de CI/CD criado anteriormente a encontre.
4) Preciso de bonecos - eu poderia fazer meus próprios no 3d studio ou blender, encomendar de alguem ou pegar na asset store. Escolhi pegar o **LOWPOLY MEDIEVAL WORLD - Lowpoly Medieval Peasants - Free pack**. Poderia pegar a **UnityChan** mas ela, por ter sido feita pra servir de um boneco completo pelos desenvolvedores da Unity, talvez tenha animações demais prontas. Caso o Medieval Peasant não me sirva vou usá-la.
5) Importei todos os assets da package. Tenho duvidas se a Unity, na hora de gerar o executável, vai eliminar do executavel final os assets não usados. Isso é uma duvida mais pra frente
6) O diretório dos assets importados fica na raiz dos Assets do projeto, no caso do LOWPOLY MEDIEVAL WORLD ficam no diretório Polytype Studio. 
7) Criei o GameObject onde as coisas do player ficarão - o PlayerRoot. O PlayerRoot também tem um outro GameObject vazio, o PlayerCameraPOV. O objetivo é fazer o script de camera acompanhar o player, baseado no CameraFollowing. 
8) PlayerCameraPOV terá um script, que eu também chamei de PlayerCameraPOV, que irá cuidar da câmera seguir o player. O script recebe a camera (do tipo Camera) e o player root (do tipo GameObject) e no update muda a posição da câmera para ser igual a posição do PlayerCameraPOV pegando a transform.position do PlayerCameraPOV e faz o lookAt para a camera olhar para o player root. Se o player root se mover o player camera pov se move junto porque as transformações lineares são herdadas ao longo da hierarquia de componentes - se o pai sofre uma translação o filho é transladao junto.

## Dúvidas
1) Os assets devem ser incluídos no controle de versão? Minha suspeita é que devem sim ser incluídos pq eles são parte do projeto, são necessários para o projeto rodar e podem ser modificados, já que suas meshes, texturas, sons e scripts também vem com o projeto.
## Bibliografia
1) https://gamedevacademy.org/how-to-create-animations-from-models-and-sprites-within-unity/
