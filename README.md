# カジノゲーム（制作途中）
## 概要
ポーカーxローグライトの名作ゲーム「Balatro」を参考に、自分の好きなコンテンツの二次創作ゲームを作る。  
[ポーカーで作った役] x [場のカードで構成されているユニット] = [スコア]で、スコアを稼いで目標点数を目指すローグライト。

## 開発期間
2024年11月 ~ 現在  
2025年4月公開目標

## 使用技術
Unity 2021.3.28f1  
UniTask  
UniRx // R3に変更予定  
DoTween

## 公開先
WebGLビルドしてレンタルサーバで公開予定

## デプロイ
GithubActionsでFFFTP経由のデプロイを実装予定

## ディレクトリ構成
```bash
.
├── .vscode
├── .gitignore
├── .gitattributes
├── Packages
└── Assets
    ├── Images // 画像を格納
    ├── Resources 
    ├── Scenes // 一旦ポーカー部分が完成した段階をV1、追加機能をコピー後のV2で実装していく
    ├── TextMesh Pro // 一旦日本語フォントにNotoSans JPを使用
    └── Scripts
        ├── Poker // ポーカー部分の管理、計算、カード 
        └── Util // モデルや共通の変数、辞書をまとめる
```

## 完成している機能
* ポーカー部分  
    * ディール→交換→チェックx３回をワンセットとしたループ
* ユニット判定
    * 選択したカードと同じユニットのカードが場にある場合、強調される
    * ワンセット終了時に場のカードで構成されるユニットを判定

## 今後やること
* コーディング
    * ローグライト部分
        * ワンセットで目標のスコアを達成→レリック（判定されるユニットのまとまり）を獲得の流れの実装
        * 初期デッキの選択（現在キャラクター全員がデッキに入っているが、属性ごとに構成されたデッキも作る）
        * お助けアイテム？？？（レリック獲得までの流れができたら、難易度調整に考える）
    * ショップ
        * 稼いだスコアでレリックやデッキを開放させる
    * テキストボックス
        * ディーラーキャラにポーカーの結果で一喜一憂させる
    * ユーザーデータ管理
        * WebGLビルド予定なので、Cookieで保管を実装する
* デザイン
    * イラスト
        * 自分で描いてもいいが、52人分のカードイラストを描きながらコーディングしていたら間に合わないので、年内に誰に依頼するか決める
    * UI/UX
        * 友人に依頼
