## シーン分割
BAGDでは原則シーンファイルを複数展開しながらゲームを進行させる。  

## BootScene
該当シーン: Boot
このシーンは`Addressable`に含まれないUnityのビルド対象に含まれるシーン。  
いくつかのアプリケーションにおける基本的なサービスを用意して永続化する。  
ゲーム的なサービスはCoreに配置される

## CoreScene
該当シーン: Core  
Coreシーンはゲーム全体に共通する項目のセットアップ及び永続化して`Title`へ遷移する。  
この際Coreシーンは破棄される。  

## BaseScene
該当シーン: [Title, PlayGround, ...]  
実質的な親となるシーン。  
これらのシーンは**CoreSceneと違って永続化を行わないため破棄されるオブジェクトのみ配置する**。  
`RootScene`は`SubScene`を持つことができ、自シーン内では自由にロード/アンロードを行って良い。
ただし、RootScene自体の遷移時は`全てのSubSceneを破棄する必要がある`。

## SubScene
該当シーン: [Schale, AbandonedFactory, ...]  
BaseSceneに紐づくシーン。  
Lightmap/NavMesh等、シーンとstaticに関連づく必要があるオブジェクトのために存在している。  
決まったBaseSceneの中でロード/アンロードされる可能性がある。  

## なんでMultiScene？
+ CoreScene
  + エディタ実行が楽
  + DontDestroyOnLoadが非推奨感のある文章で説明されているので万一廃止された場合はこのシーンを生き残るようにすれば対応できる
+ BaseScene/SubScene
  + エディタからの初期化時に複数のシーンにまたがって編集する事が多いため
  + Lightmap/NavMeshのベイクがシーンかつstaticと関連付くため
  + VContainerの相性が良く、直感的に親子を組める
    + 子と親を分離する事でシーン内における責務が分かりやすくなる
