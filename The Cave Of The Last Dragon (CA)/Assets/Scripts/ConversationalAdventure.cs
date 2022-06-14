//Game: The Cave Of The Last Dragon
//Genre: Conversational Adventure
//Editor: Manu Moral

using UnityEngine;
using TMPro;

namespace UnityMiniGames
{
    public class ConversationalAdventure : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _textScreen, _instructionTips;
        [SerializeField] TextMeshProUGUI _placeholder, _inputField;
        bool _haveName, _rustySwordOnRoom1, _rustySwordOnRoom2, _haveRustySword, 
            _canGoUp, _canGoDown, _canGoLeft, _canGoRight,_firstTime;
        int _currentRoom, _roomAtN, _roomAtS, _roomAtW, _roomAtE, _livePoints, _availableSlots;
        string _inputs,_name,_currentRoomDesc, _item, _target, _helpTips;
        public string[] _items, _targets;
        string[] _inventory = new string[2];
        string[] _itemsAtRoom = new string[3];

        void Start()
        {
            SetInitialStatus();
        }

 
        void Update()
        {
            if (_livePoints <= 0) GameOver();
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!_haveName)
                {
                    SaveName(_inputs);
                    EnterToRoom(0);
                    Invoke(nameof(ShowRoomDescription), 1f);
                    Invoke(nameof(HelpTips), 1f);
                    _haveName = true;
                }
                else
                {
                    _firstTime = false;
                    LoadInstructions(_inputs);
                    CleanInstructions();
                    CleanInstructionsTips();
                }
                
            }
        }

        public void ReadStringInput(string stringInput)
        {
            _inputs = stringInput;
        }

        void SetInitialStatus()
        {
            _livePoints = 3;
            _firstTime = true;
            _inventory[0] = _items[0];
            _inventory[1] = _items[0];

            _itemsAtRoom[0] = _items[0];
            _itemsAtRoom[1] = _items[0];
            _itemsAtRoom[2] = _items[0];

            _haveRustySword = false;

            _textScreen.text = "> Bienvenido a la Gruta del Último Dragón,\n" +
                "una intrincada sima que esconde valiosos tesoros y letales amenazas.\n" + "\n" +
                "¿Te atreves a explorar?\n" + "Si es así, di tu nombre y demuestra tu valía.";

            _helpTips = "Escribe aquí tu Nombre para comenzar la partida." +
            " Luego pulsa Enter";
            _instructionTips.text = _helpTips;

            if (Random.value >= .5f) _rustySwordOnRoom1 = true;
            else _rustySwordOnRoom2 = true;

            EnterToRoom(0);
        }

        void HelpTips()
        {
            _helpTips = "Introduce tu Primera acción." +
                " Luego pulsa Enter";
            _instructionTips.text = _helpTips;
        }

        void SaveName(string name)
        {
            _name = name;
        }

        void LoadInstructions(string cmd)
        {
            //Ir
            if (cmd == "ir n") GoNorth();
            else if (cmd == "ir s") GoSouth();
            else if (cmd == "ir o") GoWest();
            else if (cmd == "ir e") GoEast();

            //Mirar
            else if (cmd == "mirar espada oxidada") ShowItemDescription("Espada Oxidada");

            //Coger
            else if (cmd == "coger espada oxidada" && _currentRoom == 1 && _rustySwordOnRoom1) CatchOxidSword();
            else if (cmd == "coger espada oxidada" && _currentRoom == 2 && _rustySwordOnRoom2) CatchOxidSword();
            //Equipo
            else if (cmd == "equipo") ShowInventory();
            //Usar

            //Ayuda
            else if (cmd == "ayuda") ShowHelp();
            //Comando Desconocido
            else WrongCommand();
        }

        void CleanInstructions()
        {
            
        }

        void CleanInstructionsTips()
        {
            _helpTips = "Puedes escribir < ayuda > para ver los comandos disponibles.";
            _instructionTips.text = _helpTips;
        }

        #region MOVE
        void GoNorth()
        {
            if (!_canGoUp)
            {
                ICantGoThere();
            }
            else
            {
                EnterToRoom(_roomAtN);
                ShowRoomDescription();
            }
        }

        void GoSouth()
        {
            if (!_canGoDown)
            {
                ICantGoThere();
            }
            else
            {
                EnterToRoom(_roomAtS);
                ShowRoomDescription();
            }
        }

        void GoWest()
        {
            if (!_canGoLeft)
            {
                ICantGoThere();
            }
            else
            {
                EnterToRoom(_roomAtW);
                ShowRoomDescription();
            }
        }

        void GoEast()
        {
            if (!_canGoRight)
            {
                ICantGoThere();
            }
            else
            {
                EnterToRoom(_roomAtE);
                ShowRoomDescription();
            }
        }

        #endregion

        void ShowInventory()
        {
            for (int i = 0; i < _inventory.Length; i++)
            {
                if (_inventory[i] == "Slot Vacío")
                {
                    _availableSlots++;
                }
            }
            
            _textScreen.text = "> Inventario: \n" + "Hueco 1 : " + _inventory[0] + "\n" +
                "Hueco 2 : " + _inventory[1] + "\n" +
                "Huecos disponibles: " + _availableSlots;
        }

        void ShowItemDescription(string item)
        {
            if (item == _inventory[0] 
                || item == _inventory[1] 
                || item == _itemsAtRoom[0] 
                || item == _itemsAtRoom[1] 
                || item == _itemsAtRoom[2])
            {
                ItemDescription(item);
            }
            else
            {
                _textScreen.text = "> No se encuentra el objeto a examinar.";
            }
        }

        void CatchOxidSword()
        {
            _textScreen.text = "> Has cogido la Espada Oxidada, la limpias un poco y la guardas en tu Inventario.";
            _haveRustySword = true;
            _inventory[0] = _items[2];
            _itemsAtRoom[0] = _items[0];
            Debug.Log(_inventory[0]);
            _rustySwordOnRoom1 = false;
            _rustySwordOnRoom2 = false;
        }

        void ShowHelp()
        {
            _textScreen.text = "> Comandos: \n" + 
                "ir [n|s|e|o]: Mueve al personaje a la habitación siguiente en la dirección indicada (norte, sur, " +
                "este u oeste) si existe, en cuyo caso muestra una descripción de lo que hay en dicha habitación. " +
                "Si no existe, se muestra una advertencia.\n" +
                "mirar <objetivo>: Da una descripción de algo en la habitación o un objeto del Inventario.\n" +
                "coger <objeto>: Añade el objeto al Inventario (si no está lleno).\n" +
                "dejar <objeto>: Saca el objeto del Inventario y lo suelta en la habitación.\n" +
                "equipo: Muestra los objetos y cuánto espacio queda.\n" +
                "usar <objeto> <objetivo>: Hace que interactúe un objeto del Inventario con algo en la habitación u otro objeto del Inventario.\n" +
                "ayuda: Muestra estas acciones con su descripción.\n" +
                "<desconocido>: Devuelve un mensaje de error.\n" +
                "Actualmente dispones de: " + _livePoints + " vidas.";
        }

        void EnterToRoom(int currentRoom)
        {
            switch (currentRoom)
            {
                case 0: //Room 0: Comienzo
                    _canGoUp = false;
                    _canGoDown = true;
                    _canGoLeft = false;
                    _canGoRight = true;

                    _roomAtE = 2;
                    _roomAtS = 1;

                    _currentRoom = 0;

                    if (_firstTime)
                    {
                        _currentRoomDesc = "> Valiente " + _name + " has atravesado la entrada de la Gruta que da a un angosto pasillo," +
                        " una gran roca cae tras de ti obstruyendo la entrada y posible escapatoria...\n " +
                        "Una vez que se disipa el polvo, apenas puedes ver las paredes, tímidamente alumbradas por un par de Antorchas.\n" +
                        "Distingues unos grabados con forma de Dragón en los muros, que apuntan a tres posibles salidas...\n" +
                        "¿Que decides hacer?";
                    }
                    else
                    {
                        _currentRoomDesc = "> Has vuelto a la antesala repleta de grabados con forma de Dragón, tienes dos posibles salidas";
                    }
           
                    break;
                case 1: //Room 1:
                    _canGoUp = true;
                    _canGoDown = false;
                    _canGoLeft = false;
                    _canGoRight = true;

                    _roomAtN = 0;
                    _roomAtE = 3;
                    _currentRoom = 1;

                    if (_rustySwordOnRoom1)
                    {
                        _itemsAtRoom[0] = _items[2];
                        _currentRoomDesc = "> Audaz " + _name + " has accedido a una galería al sur de la entrada,\n" +
                            "que desemboca en una pequeña sala en la que se distinguen jarrones rotos y polvorientos, " +
                            "y entre ellos, una mohosa y oxidada Espada cubierta de tela de araña.\n" +
                            "\n" +
                            "[espada oxidada]";
                    }
                    else
                    {
                        _currentRoomDesc = "> Audaz " + _name + " has accedido a una galería al sur de la entrada,\n" +
                            "que desemboca en una pequeña sala en la que se distinguen jarrones rotos y polvorientos.";
                    }
                    break;
                case 2: //Room 2:
                    _canGoUp = false;
                    _canGoDown = true;
                    _canGoLeft = true;
                    _canGoRight = false;

                    _roomAtW = 0;
                    _roomAtS = 3;

                    _currentRoom = 2;

                    if (_rustySwordOnRoom2)
                    {
                        _itemsAtRoom[0] = _items[2];
                        _currentRoomDesc = "> Audaz " + _name + " has accedido a una galería al este de la entrada,\n" +
                            "que desemboca en una gran sala en la que se yerguen cuatro efigies rotas y polvorientas, " +
                            "y entre ellas, una mohosa y oxidada Espada cubierta de telas de araña.\n" +
                            "\n" +
                            "[espada oxidada]";
                    }
                    else
                    {
                        _currentRoomDesc = "> Audaz " + _name + " has accedido a una galería al este de la entrada,\n" +
                            "que desemboca en una gran sala en la que se yerguen cuatro efigies rotas y polvorientas.";
                    }
                    break;
            }
        }


        //Diálogos Preestablecidos

        void GameOver()
        {
            _textScreen.text = "> Gran" + _name + " has fallecido! Fin de la Partida.";
            SetInitialStatus();
        }
        
        void WrongCommand()
        {
            _textScreen.text = "> No puedes hacer eso, honorable " + _name + ".";
        }
        
        void ICantGoThere()
        {
            _textScreen.text = "> No puedes ir por esa dirección, valiente " + _name + ", el paso está bloqueado.";
        }

        void ShowRoomDescription()
        {
            _textScreen.text = _currentRoomDesc;
        }

        //Descripciones de Objetos y Objetivos

        void ItemDescription(string item)
        {
            if (item == _items[1]) //Llave
            {
                _textScreen.text = "> Miras la llave: ...";
            }
            else if (item == _items[2]) //Espada Oxidada
            {
                _textScreen.text = "> Contemplas la Espada Oxidada: \n" + 
                    "Tiene un aspecto rudo y ancestral, parece haber pertenecido antaño a un Rey o a un valiente guerrero curtido en mil batallas. \n" +
                    "Contiene unas Runas desgastadas en la hoja y un rubí engastado en el pomo.";
            }
        }
    }
}

