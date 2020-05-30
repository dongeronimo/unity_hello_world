# Reuso de animações

O objetivo é pegar as máquinas de estados de animações dos vários bonecos e combiná-las para reaproveitar as animações. No momento eu sou capaz de pegar o Animator Controller de um boneco e usar em outro mas não sou capaz de fundir os estados de varios Animator Controllers em um unico animator controller.

## Início
- Criei um game object vazio chamado Boneco e pus um dos PTMedievalMalePeasant nele. Nesse primeiro momento não me importarei com questões de camera então não farei o mecanismo padrão que eu faço de camera follow.
- O PTMedievalMale já vem com um animator, sem controller e com o avatar feito pela equipe que criou o boneco. Se eu botar um controller como eu fiz em Character Animation eu terei como controla-lo. Mas o que eu quero é fundir animações em um unico controller.

## Animator Controller
- Criei um animator controller, BonecoController.
- Pus esse controller no PTMedievalMale. Ele só tem dois estados iniciais, o AnyState e o Entry.
- Quando dou play ele fica preso no entry pq ele não tem estado para ir.
