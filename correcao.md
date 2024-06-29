# POO - COMIDINHAS VEGANAS

## Critérios
- Apresentaçao 	100%			(3.0)
- Modularidade 	70%				(2.1)
- Alocar mesa e rodar fila 100%	(2.0)
- Anotar pedido 85%				(1.7)
- Café e processos 	80%			(1.6)
- Documentação 		100%		(3.0)

## Comentários
- Modularidade e processos: vejam que "cadastrar cliente" pra Café e Restaurante deveria ser igual. O "atender" que não é. (e é sempre melhor passar o objeto do que os valores isolados como parâmetros).
- Modularidade: método "vincularMesa" no Café acaba desrespeitando o ISP. 
- Processos: além de o produto não ser por id, ainda está exigindo maiúscula/minúsculas. Aí é demais. 
- Validação de quantidade de itens e exceção... 
- Throw e catch no mesmo método do estabelecimento!! Ele cria o problema e "resolve"? (ou não resolve, pois o catch está vazio...
- Não vejo necessidade de "pedido" e "comanda". Um pedido é uma comanda (ou estou enganado)? No máximo seria o caso de usar uma classe genérica (um pedido tem itens, uma comanda tem pedidos) 
- Quem é o fã de Conga do grupo? 😂
