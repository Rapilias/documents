# 概要
主にUnity に関連するメモ

## Unity Latest
レンダーパイプラインとライティングソリューションの選択と設定   
https://docs.unity3d.com/ja/2022.1/Manual/BestPracticeLightingPipelines.html  
  
### Colliderを無視して接地判定される場合がある
+ NavMeshAgentが動いていないかチェック
  + 止められない場合はNavMesh自体を最適化する

### Reload Assemblyが遅い 特にテクスチャのロードに時間が掛かる
BuildSettings -> TextureCompressionをForce Uncompressに変更

### エディタUIが0.5 ~ 1s程度時折フリーズする
DeepProfileを刺して同じ動作を行う 以下は引っかかったもの
+ エディタ実装が重い 
  + SmartAddresser -> https://github.com/CyberAgentGameEntertainment/SmartAddresser/issues/46 等
+ UpdateSceneIfNeeded が重い -> 何故かAnimatorの再描画に1秒近くかかる場合がある


## ビルド成果物でネットワークアクセスが要求される
https://forum.unity.com/threads/cant-turn-off-performance-reporting-on-unity-free-version.514357/
```md
1. Edit > Project Settings > Editor > Asset Serialziation = Force Text
2. Open "ProjectSettings/UnityConnectSettings.asset" in a text editor
3. Find the "CrashReportingSettings" section.
4. Replace "m_Enabled: 1" with "m_Enabled: 0".
```

## UI
### 透過部のクリック判定を無くす
対象の画像ファイルの`Read/Write` を有効にして`Image.alphaHitTestMinimumThreshold`を変更

## TextMeshPro
### 一部の文字　の背景がわずかに白くなる
![スクリーンショット 2022-03-13 015319](https://user-images.githubusercontent.com/91034223/158027224-e5d7aa9a-6c9e-4c42-88cb-7fe0e4442adf.png)  
-> FontCreatorの`Sampling Point Size`をCustomにして32 ~ 128辺りに それでも起きるなら`Padding`が足りていないので引き上げる  
また、CanvasのScaleが正しく飛んでいない場合もあるので、Transformの見直しやCancasScalerのチェックを行い、だめならTextMeshPro/Distance Field SSD シェーダに切り替える
### Dynamicでも`Unable to add the requested character to font asset [*]'s atlas texture. Please make the texture [*] readable.`が出る
InspectorをDebugに切り替え、対象のアトラステクスチャのreadableを有効にする
## ShaderGraph
### UIに適応したMaterialがGameViewで壊れる
CameraをOverlayからCameraSpaceに切り替える
https://github.com/Rapilias/documents/issues/151 を参照

CameraStacking経由で別のCameraSpaceのDepthを無視したOverlayCameraに配置する事で回避できる

https://forum.unity.com/threads/unity-2023-2-beta-feature-highlights.1462637/
`UGUI Support for Shader Graph` で正式対応？

### Sprite系シェーダのαが認識されない
ImageTypeはSimple以外死ぬので切る
また、PreserveAspectが有効だとタイリングに支障が出る

## Cinemachine
### No Rest POVのLookAtが変えられない
InspectorをDebugに切り替える

## VContainer
### RegisterEntryPointしたインスタンスを`[InjectAttribute]`で参照したい
多I/F参照の際と同様に
```csharp
RegisterEntryPoint<T>(lifetime).As<T>();
```
### シーンを跨いだ際の初期化
https://github.com/Rapilias/documents/issues/176#issuecomment-1129252500 等

### Injectされない要素があるのにエラーにならない
継承の派生元はprotectedでないとInject対象にならない

## MessagePack
### シリアライズ→デシリアライズが通らない バイト列の不整合に見える
`UnionAttribute`の付与を確認した上で **シリアライズ時にI/Fで投げ込む**
 
## DoozyUI
### LayoutSystemに載せた要素が実行時にLayoutを無視して1カ所に固まる
+ AnimationのMoveを切る
+ Custom Start Positionを無効にする

### ToggleのActiveが切れて見える問題
UIToggleはSelectableであるものの、SelectableAnimatorを適応するとEventSystemのcurrentSelecteObjectに反応してしまうため、非アクティブになったように見えてしまう
Callbackから手でAnimationに繋がるコールバックを呼び出す

## Dynamic Radial Mask
`Dynamic Radial Mask`(以下`DRM`と呼称)は円形マスク全般のシェーダに利用できるパーツとそこへの入力をある程度良い感じにできる
+ DRM Editor Windowで特定のプロパティを持つクラスとシェーダ定義を作成
  + GPUに投げ込む都合で固定長が必須のためこの工程が必要
+ シェーダ内で生成したノードを読む -> ShaderGraph / cging
+ スクリプトからパラメータを入力 -> DRMXX

## Addressable
### ビルド済みアセットを参照する時、キーが一致していてもKeyNotFoundになる
Groupの設定に`Include Address in Catalog`を有効化する必要がある

## IDMap
- [x] 1 Reveved
- [ ] 2
- [ ] 3
- [ ] 4
- [ ] 5
- [ ] 6
- [ ] 7
- [ ] 8
- [ ] 9
- [ ] 10
- [ ] 11
- [ ] 12
- [ ] 13
- [ ] 14
- [ ] 15 PortalCollision
- [x] 16 Portal

## TestRunner
### 2.0.xと1.3.x どっち使えばいい？
1.3.x 
2.0.x は公式からまだ安定していないと言及がある

### `Assert.ThrowsAsync()`で無限ループに陥る 
テスト自体がメインスレッドで実行されるためデッドロックする場合がある   
更に、この場合`Timeout`属性も効かない  

```cs
        [Test]
        public async Task TestAsync()
        {
            await UniTask.SwitchToThreadPool();
            Assert.ThrowsAsync<T>(async () => /**/);
        }
```
で実行する
