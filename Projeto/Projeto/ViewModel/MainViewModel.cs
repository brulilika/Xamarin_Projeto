using Xamarin.Forms;

namespace Projeto.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        #region Propriedades
        //Command dos demais botoes
        private Command _limpaCommand;
        private Command _zeraCommand;
        private Command _multiCommand;
        private Command _divCommand;
        private Command _minCommand;
        private Command _plusCommand;
        private Command _comCommand;
        private Command _equalCommand;

        //Command dos botoes numericos
        private Command _zeroCommand;
        private Command _umCommand;
        private Command _doisCommand;
        private Command _tresCommand;
        private Command _quatroCommand;
        private Command _cincoCommand;
        private Command _seisCommand;
        private Command _seteCommand;
        private Command _oitoCommand;
        private Command _noveCommand;

        private string _texto; //texto no Entry
        private string _result; //label com resultado
        private string _op; //label com ultimo operador usado
        #endregion
        public MainViewModel(){
            Result = "Resultado";
            Op = "Operador";
        }

        #region Encapsulamento
        public string Texto { get { return _texto; } set { _texto = value; OnPropertyChanged("Texto"); } }
        public string Result { get { return _result; } set { _result = value; OnPropertyChanged("Result"); } }
        public string Op { get { return _op; } set { _op = value; OnPropertyChanged("Op"); } }

        public Command LimpaCommand => _limpaCommand ?? (_limpaCommand = new Command(() => //funcao para tirar o ultimo caracter da string
        {
            string novo = "";
            if (Texto != "")
            { 
                //se tiver algo dentro do Texto:
                //copia conteudo do Texto para novo, tirando o ultimo caracter
                for (int i = 0; i < Texto.Length - 1; i++)
                {
                    novo += Texto[i];
                }
                Texto = novo;
            }
            else
            {
                //se o campo Texto estiver vazio
                //desativar botao de limpar
            }
        }));
        public Command ZeraCommand => _zeraCommand ?? (_zeraCommand = new Command(() => //funcao para zerar todas as contas feitas
        {
            Result = "Resultado";
            Op = "Operador";
            Texto = "";
        }));
        public Command MultiCommand => _multiCommand ?? (_multiCommand = new Command(() => //funcao para multiplicar valores
        {
            if (Texto == "") //Entry vazio
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Campo de entrada não possui dados para conta ser realizada!", "OK");
            }
            else
            {
                if (Result == "Resultado") //nenhuma conta foi realizada
                {
                    Result = Texto;
                    Op = "*";
                    Texto = "";
                }
                else
                { //ja tem algo no Result
                    Result = (double.Parse(Result) * double.Parse(Texto)).ToString();
                    Op = "*";
                    Texto = "";
                }
            }
            
        }));

        public Command DivCommand => _divCommand ?? (_divCommand = new Command(() => //funcao para dividir valores
        {
            if (Texto == "") //Entry vazio
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Campo de entrada não possui dados para conta ser realizada!", "OK");
            }
            else
            {
                if(Texto == "0")
                {
                    App.Current.MainPage.DisplayAlert("Atenção", "Não se pode realizar divisão por zero!", "OK");
                }
                else
                {
                    if (Result == "Resultado") //nenhuma conta foi realizada
                    {
                        Result = Texto;
                        Op = "/";
                        Texto = "";
                    }
                    else
                    { //ja tem algo no Result
                        Result = (double.Parse(Result) / double.Parse(Texto)).ToString();
                        Op = "/";
                        Texto = "";
                    }
                }
            }
        }));
        public Command MinCommand => _minCommand ?? (_minCommand = new Command(() => //funcao para subtrair valores
        {
            if (Texto == "") //Entry vazio
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Campo de entrada não possui dados para conta ser realizada!", "OK");
            }
            else
            {
                if (Result == "Resultado") //nenhuma conta foi realizada
                {
                    Result = Texto;
                    Op = "-";
                    Texto = "";
                }
                else
                { //ja tem algo no Result
                    Result = (double.Parse(Result) - double.Parse(Texto)).ToString();
                    Op = "-";
                    Texto = "";
                }
            }
            
        }));
        public Command PlusCommand => _plusCommand ?? (_plusCommand = new Command(() => //funcao para subtrair valores
        {
            if (Texto == "") //Entry vazio
            {
                App.Current.MainPage.DisplayAlert("Atenção", "Campo de entrada não possui dados para conta ser realizada!", "OK");
            }
            else
            {
                if (Result == "Resultado") //nenhuma conta foi realizada
                {
                    Result = Texto;
                    Op = "+";
                    Texto = "";
                }
                else
                { //ja tem algo no Result
                    Result = (double.Parse(Texto) + double.Parse(Result)).ToString();
                    Op = "+";
                    Texto = "";
                }
            }
 
        }));
        public Command ComCommand => _comCommand ?? (_comCommand = new Command(() => //funcao para colocar uma virgula
        {
            Texto += ".";
        }));
        public Command EqualCommand => _equalCommand ?? (_equalCommand = new Command(() => //funcao para subtrair valores
        {
            if (Texto == "") //Entry vazio
            {
                if (Result == "Resultado") App.Current.MainPage.DisplayAlert("Atenção", "Nenhuma conta foi realizada até o momento!", "OK");
                else App.Current.MainPage.DisplayAlert("Atualizando", "O resultado da sua conta até o momento é:" + Result, "OK");
            }

            else
            {
                switch (Op)
                {
                    case "+":
                        Result = (double.Parse(Texto) + double.Parse(Result)).ToString();
                        break;
                    case "-":
                        Result = (double.Parse(Result) - double.Parse(Texto)).ToString();
                        break;
                    case "*":
                        Result = (double.Parse(Result) * double.Parse(Texto)).ToString();
                        break;
                    case "/":
                        if(Texto == "0")
                        {
                            App.Current.MainPage.DisplayAlert("Atenção", "Não se pode realizar divisão por zero!", "OK");
                        }
                        else
                        {
                            if (Result == "Resultado") //nenhuma conta foi realizada
                            {
                                Result = Texto;
                                Op = "/";
                                Texto = "";
                            }
                            else
                            { //ja tem algo no Result
                                //falta validar divisao por 0<x<1
                                Result = (double.Parse(Result) / double.Parse(Texto)).ToString();
                                Op = "/";
                                Texto = "";
                            }
                        }
                        Result = (double.Parse(Result) / double.Parse(Texto)).ToString();
                        break;
                }
                Texto = "";
            }
            
            
        }));
        public Command ZeroCommand => _zeroCommand ?? (_zeroCommand = new Command(() =>
        {
            Texto = Texto + "0";
        }));
        public Command UmCommand => _umCommand ?? (_umCommand = new Command(() =>
        {
            Texto = Texto + "1";
        }));
        public Command DoisCommand => _doisCommand ?? (_doisCommand = new Command(() =>
        {
            Texto = Texto + "2";
        }));
        public Command TresCommand => _tresCommand ?? (_tresCommand = new Command(() =>
        {
            Texto = Texto + "3";
        }));
        public Command QuatroCommand => _quatroCommand ?? (_quatroCommand = new Command(() =>
        {
            Texto = Texto + "4";
        }));
        public Command CincoCommand => _cincoCommand ?? (_cincoCommand = new Command(() =>
        {
            Texto = Texto + "5";
        }));
        public Command SeisCommand => _seisCommand ?? (_seisCommand = new Command(() =>
        {
            Texto = Texto + "6";
        }));
        public Command SeteCommand => _seteCommand ?? (_seteCommand = new Command( () =>
        {
            Texto = Texto + "7";
        }));
        public Command OitoCommand => _oitoCommand ?? (_oitoCommand = new Command(() =>
        {
            Texto = Texto + "8";
        }));
        public Command NoveCommand => _noveCommand ?? (_noveCommand = new Command(() =>
        {
            Texto = Texto + "9";
        }));
        #endregion
    }
}
