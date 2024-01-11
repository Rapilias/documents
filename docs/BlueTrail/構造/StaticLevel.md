## StaticLevel
ステージは事前に決められた法則に従って様々なランダム要素を生成する。  
この法則がStaticに決められるため`StaticLevel`と呼称しており、この法則も動的になるパターンが必要になった場合は`DynamicLevel`が作成される。  
法則は`LevelStageInfoAsset`とその子によって決定される。


## LevelStageInfoAsset
単一のモデルを使用するステージを管理する。
この階層では、単一のステージ内で共通して利用される要素群を設定できる。
ここからステージの難易度や特殊な敵を配置する等を`LevelStageDetailAsset`で表現していく。

## LevelStageDetailAsset
ステージの単一のLevelを管理する。
ここでどのLocatorGroupに何をどのように配置していくか を設定できる。