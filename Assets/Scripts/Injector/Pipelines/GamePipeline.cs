using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Injection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Scripts
{
    public class GamePipeline : MonoBehaviour
    {
        #region [Fields]
        [field: SerializeField] private InventoryView InventoryView{ get; set; }
        [field: SerializeField] private ManagerData ManagerData{ get; set; }
        [field: SerializeField] private ManagerDrop ManagerDrop{ get; set; }
        [field: SerializeField] private ManagerInput ManagerInput{ get; set; }
        [field: SerializeField] private InventoryWidget InventoryWidget{ get; set; }
        [field: SerializeField] private Player Player{ get; set; }
        
        
        private Injector _injector;
        private readonly GamePipelineUpdater _updater = new();

        private readonly InjectionsBinder[] _preInitializedBinders = { new ConfigBinder(), };
        #endregion
        
        #region [Functions]
        public void Awake()
        {
            Application.targetFrameRate = 60;
            _injector = new Injector();
            InjectComponents(_injector);
            InitializeComponents(_injector);
        }

        public void BindingComponent<T>(T obj)
        {
            _injector.Bind(obj);
            _injector.CommitBindings();
        }

        private void InjectComponents(Injector injector)
        {
            injector.Bind(injector);
            injector.Bind(Camera.main);
            injector.Bind(EventSystem.current);
            
            injector.Bind(new InjectionInstantiator(injector));

            injector.Bind(InventoryView);
            injector.Bind(ManagerData);
            injector.Bind(ManagerInput);
            injector.Bind(ManagerDrop);
            injector.Bind(Player);
            injector.InjectTo(InventoryWidget);
            // injector.Bind(ManagerAccount);
            // injector.Bind(ManagerSound);
            
            // injector.Bind(ViewMainMenu);
            // injector.Bind(WidgetsMainMenu);
            // injector.Bind(ViewTotalizator);
            // injector.Bind(ViewSearchMatch);
            
            injector.CommitBindings();
            ManagerDrop.Initialize();
            DropConfig dropConfig = ManagerDrop.GetDrop(EUnit.Bat);
            Debug.Log($"DropConfig.Key={dropConfig.Key}\tdropConfig.DropDatas.Count={dropConfig.DropData.Count}");
            
            InitializeViews();
            //ManagerData.Views = InventoryView;
            // ManagerData.SelectPlatformMobile();
            //
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetOffers);
            // WidgetsMainMenu.SelectedContainer.WidgetsCurrencies.ForEach(x=>injector.InjectTo(x));
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetSettings);
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetBattlePass);
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetDailyQuest);
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetLuckyTicket);
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetLuckyWheel);
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetSlotMachine);
            // injector.Bind(WidgetsMainMenu.SelectedContainer.WidgetButtonPlay);
            //
            // injector.Bind(ViewTotalizator.SelectedContainer.WidgetButtonCoins);
            // injector.Bind(ViewTotalizator.SelectedContainer.WidgetButtonHero);
            // injector.Bind(ViewTotalizator.SelectedContainer.WidgetButtonLimbs);
            // injector.Bind(ViewTotalizator.SelectedContainer.WidgetButtonBack);
            // injector.Bind(ViewTotalizator.SelectedContainer.WidgetButtonOk);
            //
            // injector.Bind(ViewTotalizator.SelectedContainer.WidgetCoinsPanel);
            // ViewTotalizator.SelectedContainer.WidgetCoinsPanel.WidgetButtonCoinMultipliers.ForEach(x => injector.InjectTo(x));
            

            injector.CommitBindings();
            
            //ManagerData.GameStart();

        }

        private void InitializeViews()
        {
            // ManagerData.AddIView(ViewMainMenu);
            // ManagerData.AddIView(WidgetsMainMenu);
            // ManagerData.AddIView(ViewTotalizator);
            // ManagerData.AddIView(ViewSearchMatch);
        }

        private void InitializeComponents(Injector injector)
        {
            var orderedHandlers = GetAll<IPipelineInitialized>(injector).OrderBy(GetOrder);
            foreach (IPipelineInitialized handler in orderedHandlers)
                handler.Initialize();

            RegisterKeyboardHandlers();
            _updater.Register(injector);
            
        }

        private int GetOrder(IPipelineInitialized handler)
        {
            var attr = handler.GetType().GetCustomAttribute<InitializationOrderAttribute>();
            return attr?.Order ?? 0;
        }

        private void RegisterKeyboardHandlers()
        {
            // KeyboardManager keyboardManager = FindObjectOfType<KeyboardManager>();
            // GetAll<IKeyUpHandler>(_injector).ForEach(keyUpHandler => keyboardManager.Register(keyUpHandler));
            // GetAll<IKeyDownHandler>(_injector).ForEach(keyDownHandler => keyboardManager.Register(keyDownHandler));
            // GetAll<IKeyHandler>(_injector).ForEach(keyHandler => keyboardManager.Register(keyHandler));
            // GetAll<IMouseScrollHandler>(_injector).ForEach(mouseScrollHandler => keyboardManager.Register(mouseScrollHandler));
        }
        
        private List<T> GetAll<T>(Injector injector)
        {
            return injector.GetAll().Where(_ => _ is T).Cast<T>().ToList();
        }

        private void Update()
        {
            _updater.OnUpdate();
        }

        private void LateUpdate()
        {
            _updater.OnLateUpdate();
        }
        #endregion

    }
}