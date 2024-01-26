using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomerController : MonoBehaviour
{
    public List<Customer> customers = new List<Customer>(); // 顾客列表
    private int currentCustomerIndex = 0; // 当前顾客的索引
    private Customer currentCustomer; // 当前正在服务的顾客
    private int score = 0;
    private int score_noTotal = 0;
     public Text scoreText;
     public Text scoreText_noTotal;
    public item thisItem;
      public Inventory playerInventory;
    void Start()
    {
        SetActiveCustomers();
    }
    void Update(){
         UpdateScoreUI();
         Checkscore();
    }

    void SetActiveCustomers()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].gameObject.SetActive(i == currentCustomerIndex);
        }

        currentCustomer = customers[currentCustomerIndex];
    }

    public void ServeIceCreamToCurrentCustomer(IceCream iceCream)
    {
        if (currentCustomer != null)
        {
            currentCustomer.CheckDeliveredIceCream(iceCream);
        }
    }

    public void MoveToNextCustomer()
    {
        // 隐藏当前客户
        currentCustomer.gameObject.SetActive(false);
       // Debug.Log("MoveToNextCustomer");
        
        // 增加索引
        currentCustomerIndex++;

        if (currentCustomerIndex < customers.Count)
        {
            // 设置下一个客户为激活状态
            currentCustomer = customers[currentCustomerIndex];
            currentCustomer.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("所有顾客都已服务完毕！");
        }
    }
      public void AddScore(int points)
    {
        score += points;
        score_noTotal= points;

    }
    public void Checkscore(){

        if(score==300){
            AddNewItem(thisItem);
            Debug.Log("恭喜獲得勝利");
        }
    }
    
    private void UpdateScoreUI()
{
    // 假設你有一個Text元件用來顯示分數，請替換成實際的UI元件
    // 例如，如果有一個名為scoreText的Text元件：
    scoreText.text = score.ToString();
    scoreText_noTotal.text = score_noTotal.ToString();

    // 如果你的UI元件有特定的名稱或位於特定的物件上，請根據實際情況調整
}
 public void AddNewItem(item thisItem){
    if(!playerInventory.itemList.Contains(thisItem)){
         //playerInventory.itemList.Add(thisItem);
          //未刪CreateNewItem
         //InventoryManager.CreateNewItem(thisItem);
         for(int i=0;i<playerInventory.itemList.Count;i++){
                if(playerInventory.itemList[i]==null){
                        playerInventory.itemList[i]=thisItem;
                        break;
                }
         }
    }
    else {
        thisItem.itemHeild += 1;
    }
    InventoryManager.RefreshItem(); 
   }
}
