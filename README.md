# unity_Shooting

書き方の例
### オブジェクトの場所
```C#
transform.position;
```
***

[googleを参考にした](https://www.google.com/?hl=ja)
***
### Clamp
```C#
Vector2型の変数を作る（player_postion）
変数にplayerの位置を格納
player_postionにplayerの位置を入れる
Mathf.Clampで
player_postionの各座標の範囲を制限可能（但し、postionの後に.x  .y  .z をそれぞれ入れる）
例）player_postion.x = Mathf.Clamp(player_postionn.x, -12,12);
 　     変数　　　　　　制限をかける（制限したい値　，最小値，最大値）

```
[Quitaを参考にした](https://qiita.com/Eureka/items/81b3d88a012ddc645ff5)
