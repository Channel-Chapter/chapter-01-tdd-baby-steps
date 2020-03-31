##  Fase 1

Criar o projeto Calculador `Calculadora.Lib`

Criar o projeto Tests `Calculadora.Lib.Tests.Unit`

Atualizar os pacotes

Cenários propostos

---
>Desenvolvedores   com Salário maior que R$ 3.000,00 receberá 20% de desconto, caso contrário, o desconto é de 10%.
>DBAs e Testadores com Salário maior que R$ 2.500,00 receberá 25% de desconto, caso contrário, o desconto é de 15%.
---

Criar classe de tests `CalculadoraDeSalarioTest`

Criar o Cenário de testes para `Desenvolvedores com salario < R$ 3.000,00`

```csharp
[Fact(DisplayName = "Cenário 01 - DEVs Com Salario Menor que R$ 3.000")]
public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite()
{
	//Arrange
	var salario = 1500.0;
	var funcionario = new Funcionario("Funcionario", salario, Cargo.Desenvolvedor);
	var salarioEsperado = salario * 0.9;

	//Act
	var salarioCalculado = new CalculadoraDeSalario().CalculaSalario(funcionario);

	//Assert
	Assert.Equal(salarioEsperado, salarioCalculado);
}
```

Criar classe `CalculadoraDeSalario`

Criar classe `Funcionario`

Criar enum `Cargo`

```csharp
public enum Cargo { Desenvolvedor, DBA, Testador }
```

Completar o objeto `Funcionario`
	
```csharp
public class Funcionario
{
	public string Nome { get; private set; }
	public double Salario { get; private set; }
	public Cargo Cargo { get; private set; }
	public Funcionario(string nome, double salario, Cargo cargo)
	{
		Nome = nome;
		Salario = salario;
		Cargo = cargo;
	}
}
```

Crair o método `CalculaSalario`

```csharp
public double CalculaSalario(Funcionario funcionario)
{
	return 1350.0;
}
```
Criar o Cenário de testes para `Desenvolvedores com salario > R$ 3.000,00`

```csharp
[Fact(DisplayName = "Cenário 02 - DEVs Com Salario Maior que R$ 3.000")]
public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAcimaDoLimite()
{
	//Arrange
	var salario = 4000.0;
	var funcionario = new Funcionario("Funcionario", salario, Cargo.Desenvolvedor);
	var salarioEsperado = salario * 0.8;

	//Act
	var salarioCalculado = new CalculadoraDeSalario().CalculaSalario(funcionario);

	//Assert
	Assert.Equal(salarioEsperado, salarioCalculado);
}
```

Ajustar o método `CalculaSalario` para contemplar novo cenário

```csharp
public double CalculaSalario(Funcionario funcionario)
{
	if (funcionario.Salario > 3000.0)
		return 3200.0;
	return 1350.0;
}
```

Criar o Cenário de testes para `DBAs com salario < R$ 2.500,00`
	
```csharp
[Fact(DisplayName = "Cenário 03 - DBAs Com Salario Menor que R$ 2.500")]
public void DeveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite()
{
	//Arrange
	var salario = 500.0;
	var funcionario = new Funcionario("Funcionario", salario, Cargo.DBA);
	var salarioEsperado = salario * 0.85;

	//Act
	var salarioCalculado = new CalculadoraDeSalario().CalculaSalario(funcionario);

	//Assert
	Assert.Equal(salarioEsperado, salarioCalculado);
}
```

Ajustar o método `CalculaSalario` para contemplar novo cenário
	
```csharp
public double CalculaSalario(Funcionario funcionario)
{
	if (funcionario.Cargo.Equals(Cargo.Desenvolvedor))
	{
		if (funcionario.Salario > 3000.0)
		{
			return 3200.0;
		}
		return 1350.0;
	}
	return 425.0;
}
```

Ajustar o método `CalculaSalario` para realizar os cálculos dos valores
	
```csharp
public double CalculaSalario(Funcionario funcionario)
{
	if (funcionario.Cargo.Equals(Cargo.Desenvolvedor))
	{
		if (funcionario.Salario > 3000.0)
		{
			return funcionario.Salario * 0.8;
		}
		return funcionario.Salario * 0.9;
	}
	return funcionario.Salario * 0.85;
}
```

Criar o Cenário de testes para `DBAs com salario > R$ 2.500,00`

```csharp
[Fact(DisplayName = "Cenário 04 - DBAs Com Salario Maior que R$ 2.500")]
public void DeveCalcularSalarioParaDBAsComSalarioAcimaDoLimite()
{
	//Arrange
	var salario = 4500.0;
	var funcionario = new Funcionario("Funcionario", salario, Cargo.DBA);
	var salarioEsperado = salario * 0.75;

	//Act
	var salarioCalculado = new CalculadoraDeSalario().CalculaSalario(funcionario);

	//Assert
	Assert.Equal(salarioEsperado, salarioCalculado);
}
```

Ajustar o método `CalculaSalario` para contemplar novo cenário

```csharp
public double CalculaSalario(Funcionario funcionario)
{
	if (funcionario.Cargo.Equals(Cargo.Desenvolvedor))
	{
		if (funcionario.Salario > 3000.0)
		{
			return funcionario.Salario * 0.8;
		}
		return funcionario.Salario * 0.9;
	}
	else if (funcionario.Cargo.Equals(Cargo.DBA))
	{
		if (funcionario.Salario < 2500.0)
		{
			return funcionario.Salario * 0.85;
		}
		return funcionario.Salario * 0.75;
	}

	throw new System.Exception("Funcionario inválido");
}
```

Criar o Cenário de testes para `Testadores com salario < R$ 2.500,00`
	
```csharp
[Fact(DisplayName = "Cenário 05 - TESTs Com Salario Menor que R$ 2.500")]
public void DeveCalcularSalarioParaTestadoresComSalarioAbaixoDoLimite()
{
	//Arrange
	var salario = 500.0;
	var funcionario = new Funcionario("Funcionario", salario, Cargo.Testador);
	var salarioEsperado = salario * 0.85;

	//Act
	var salarioCalculado = new CalculadoraDeSalario().CalculaSalario(funcionario);

	//Assert
	Assert.Equal(salarioEsperado, salarioCalculado);
}
```

Adicionar a nova regra do testador no método `CalculaSalario`
	
```csharp
|| funcionario.Cargo.Equals(Cargo.Testador)
```

Criar o Cenário de testes para `Testadores com salario > R$ 2.500,00`

```csharp
[Fact(DisplayName = "Cenário 06 - TESTs Com Salario Maior que R$ 2.500")]
public void DeveCalcularSalarioParaTestadoresComSalarioAcimaDoLimite()
{
	//Arrange
	var salario = 4500.0;
	var funcionario = new Funcionario("Funcionario", salario, Cargo.Testador);
	var salarioEsperado = salario * 0.75;

	//Act
	var salarioCalculado = new CalculadoraDeSalario().CalculaSalario(funcionario);

	//Assert
	Assert.Equal(salarioEsperado, salarioCalculado);
}
```
### Fase 1.1 - Refactory na Lib

Criar o método `DezOuVintePorCentoDeDesconto`
	
```csharp
public class CalculadoraDeSalario
{
	...
	private double DezOuVintePorCentoDeDesconto(Funcionario funcionario)
	{
		var porcentagem = funcionario.Salario > 3000.0 ? 0.8 : 0.9;
            return funcionario.Salario * porcentagem;
	}
	...
}
```

Criar o método `QuinzeOuVinteCincoPorCentoDeDesconto`
	
```csharp
public class CalculadoraDeSalario
{
	...
	private double QuinzeOuVinteCincoPorCentoDeDesconto(Funcionario funcionario)
	{
		var porcentagem = funcionario.Salario > 2500.0 ? 0.75 : 0.85;
            return funcionario.Salario * porcentagem;
	}
	...
}
```

Alterar o método `CalculaSalario`

```csharp
public double CalculaSalario(Funcionario funcionario)
{
	if (funcionario.Cargo.Equals(Cargo.Desenvolvedor))
	{
		return DezOuVintePorCentoDeDesconto(funcionario);
	}
	else if (funcionario.Cargo.Equals(Cargo.DBA) || funcionario.Cargo.Equals(Cargo.Testador))
	{
		return QuinzeOuVinteCincoPorCentoDeDesconto(funcionario);
	}
	throw new System.Exception("Funcionario inválido");
}
```

Criar classe builder `FuncionarBuilder` no projeto tests

```csharp
internal class FuncionarBuilder
{
	internal static Funcionario CriarDesenvolvedor(double salario) =>
		new Funcionario("Funcionario", salario, Cargo.Desenvolvedor);
}
```

Adicionar método

Criar método builder `CriarDBA`

```csharp
internal static Funcionario CriarDBA(double salario) => 
	new Funcionario("Funcionario", salario, Cargo.DBA);
```

Criar método builder `CriarTestador`
	
```csharp
internal static Funcionario CriarTestador(double salario) => 
	new Funcionario("Funcionario", salario, Cargo.Testador);
```

Adicionar builders `CriarTestador` aos testes

```csharp
FuncionarBuilder.CriarDesenvolvedor(salario);
FuncionarBuilder.CriarDBA(salario);
FuncionarBuilder.CriarTestador(salario);
```

Atualizar os testes para utilizar Teorias para mais testes
	
```csharp
[Theory(DisplayName = "Cenário 01 - DEVs Com Salario Menor que R$ 3.000")]
[InlineData(1500.0)]
[InlineData(2500.0)]
public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite(double salario)

[Theory(DisplayName = "Cenário 02 - DEVs Com Salario Maior que R$ 3.000")]
[InlineData(3500.0)]
[InlineData(4000.0)]
public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAcimaDoLimite(double salario)

[Theory(DisplayName = "Cenário 03 - DBAs Com Salario Menor que R$ 2.500")]
[InlineData(500.0)]
[InlineData(2000.0)]
public void DeveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite(double salario)

[Theory(DisplayName = "Cenário 04 - DBAs Com Salario Maior que R$ 2.500")]
[InlineData(2600.0)]
[InlineData(4500.0)]
public void DeveCalcularSalarioParaDBAsComSalarioAcimaDoLimite(double salario)

[Theory(DisplayName = "Cenário 05 - TESTs Com Salario Menor que R$ 2.500")]
[InlineData(500.0)]
[InlineData(1000.0)]
public void DeveCalcularSalarioParaTestadoresComSalarioAbaixoDoLimite(double salario)

[Theory(DisplayName = "Cenário 06 - TESTs Com Salario Maior que R$ 2.500")]
[InlineData(2600.0)]
[InlineData(4500.0)]
public void DeveCalcularSalarioParaTestadoresComSalarioAcimaDoLimite(double salario)
```
	
***

## Fase 2 - Refactory na Lib

Criar interface `IRegraDeCalculo`
	
```csharp
public interface IRegraDeCalculo
{
	double Calcula(Funcionario funcionario);
}
```

Criar a classe `DezOuVintePorCento`

```csharp
public class DezOuVintePorCento : IRegraDeCalculo
{
	public double Calcula(Funcionario funcionario)
	{
   		var porcentagem = funcionario.Salario > 3000.0 ? 0.8 : 0.9;
		return funcionario.Salario * porcentagem;
	}
}
```

Criar a classe `QuinzeOuVinteCincoPorCento`
	
```csharp
public class QuinzeOuVinteCincoPorCento : IRegraDeCalculo
{
	public double Calcula(Funcionario funcionario)
	{
		var porcentagem = funcionario.Salario > 2500.0 ? 0.75 : 0.85;
        return funcionario.Salario * porcentagem;
	}
}
```

Refactory da classe `Cargo`
	
```csharp
public class Cargo
{
	public IRegraDeCalculo Regra { get; private set; }

	private Cargo(IRegraDeCalculo regra)
	{
		Regra = regra;
	}

	public static Cargo Desenvolvedor => new Cargo(new DezOuVintePorCento());

	public static Cargo DBA => new Cargo(new QuinzeOuVinteCincoPorCento());

	public static Cargo Testador => new Cargo(new QuinzeOuVinteCincoPorCento());
}
```

Refactory da classe `CalculadoraDeSalario`
	
```csharp
public class CalculadoraDeSalario
{
	public double CalculaSalario(Funcionario funcionario)
	{
		return funcionario.Cargo.Regra.Calcula(funcionario);
	}
}
```

***

## Fase 3 - Refactory na Lib

Criar classe `RegraDeCalculo`
	
```csharp
public abstract class RegraDeCalculo : IRegraDeCalculo
{
	public double Calcula(Funcionario funcionario)
	{
		var porcentagem = funcionario.Salario > Limite ? PorcentagemAcimaDoLimite : PorcentagemBase;
		return funcionario.Salario * porcentagem;
	}

	protected abstract double Limite { get; }
	protected abstract double PorcentagemAcimaDoLimite { get; }
	protected abstract double PorcentagemBase { get; }
}
```

Refactory da classe `DezOuVintePorCento`
	
```csharp
public class DezOuVintePorCento : RegraDeCalculo
{
	protected override double PorcentagemBase => 0.9;
    protected override double PorcentagemAcimaDoLimite => 0.8;
    protected override double Limite => 3000.0;
}
```

Refactory da classe `QuinzeOuVinteCincoPorCento`
	
```csharp
public class QuinzeOuVinteCincoPorCento : RegraDeCalculo
{
	protected override double PorcentagemBase => 0.85;
	protected override double PorcentagemAcimaDoLimite => 0.75;
	protected override double Limite => 2500.0;
}
```

***

## Fase 4 - Refactory na Lib e nos testes

Refactory da classe `Cargo` para remover as propriedades estáticas e injetar a regra
	
```csharp
public class Cargo
{
	public IRegraDeCalculo Regra { get; private set; }

	public Cargo(IRegraDeCalculo regra)
	{
		Regra = regra;
	}
}
```

Alterar métodos da classe Builder `CriarDesenvolvedor`
	
```csharp
internal static Funcionario CriarDesenvolvedor(double salario) =>
	new Funcionario("Funcionario", salario, new Cargo(new DezOuVintePorCento()));
```

Alterar o método Builder `CriarDBA`
	
```csharp
internal static Funcionario CriarDBA(double salario) =>
	new Funcionario("Funcionario", salario, new Cargo(new QuinzeOuVinteCincoPorCento()));
```

Alterar o método Builder `CriarTestador`
	
```csharp
internal static Funcionario CriarTestador(double salario) =>
	new Funcionario("Funcionario", salario, new Cargo(new QuinzeOuVinteCincoPorCento()));
```

***

## Fase 5 - Refactory na Lib e nos testes

Alterar a classe `CalculadoraDeSalario`
	
```csharp
public class CalculadoraDeSalario
{
	IRegraDeCalculo _regraDeCalculo;

	public CalculadoraDeSalario(IRegraDeCalculo regraDeCalculo)
	{
		_regraDeCalculo = regraDeCalculo;
	}

	public double CalculaSalario(Funcionario funcionario)
	{
		return _regraDeCalculo.Calcula(funcionario);
	}
}
```

Alteração na classe `Cargo`
	
```csharp
public enum Cargo { Desenvolvedor, DBA, Testador }
```

Alteração na classe Builder
	
```csharp
internal class FuncionarBuilder
{
	internal static Funcionario CriarDesenvolvedor(double salario) =>
		new Funcionario("Funcionario", salario, Cargo.Desenvolvedor);

	internal static Funcionario CriarDBA(double salario) =>
		new Funcionario("Funcionario", salario, Cargo.DBA);

	internal static Funcionario CriarTestador(double salario) =>
		new Funcionario("Funcionario", salario, Cargo.Testador);
}
```

Ajustes nos testes no método `CalculaSalario`
	
```csharp
	new CalculadoraDeSalario(new DezOuVintePorCento()).CalculaSalario(funcionario);
	new CalculadoraDeSalario(new QuinzeOuVinteCincoPorCento()).CalculaSalario(funcionario);
```

***

## Fase 6 - Refactory na Lib e nos testes

Alterar a interface `IRegraDeCalculo` para remover a dependência do objeto Funcionário
	
```csharp
public interface IRegraDeCalculo
{
	double Calcula(double salario);
}	
```

Alterar a classe `RegraDeCalculo`
	
```csharp
public abstract class RegraDeCalculo : IRegraDeCalculo
{
	public double Calcula(double salario)
	{
		if (salario > Limite)
		{
			return salario * PorcentagemAcimaDoLimite;
		}
		return salario * PorcentagemBase;

		//var porcentagem = (salario > Limite) ? PorcentagemAcimaDoLimite : PorcentagemBase;
		//return salario * porcentagem;
	}

	protected abstract int Limite { get; }
	protected abstract double PorcentagemAcimaDoLimite { get; }
	protected abstract double PorcentagemBase { get; }
}
```

Alterar a classe `CalculadoraDeSalario`
	
```csharp
public class CalculadoraDeSalario
{
	public double CalculaSalario(double salario) =>
		regraDeCalculo.Calcula(salario);
}
```

Alterar os testes para receberem os sálarios no método `CalculaSalario`
	
```csharp
desenvolvedor.Salario
```
