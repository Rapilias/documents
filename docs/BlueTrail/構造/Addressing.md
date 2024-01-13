## 概要
Addressableの戦略周り

## ベース
Addressableの管理は [SmartAddresser](https://github.com/CyberAgentGameEntertainment/SmartAddresser) である程度自動化を行う。  
具体的にはアドレス指定と、戦略に基づいたラベルの付与を自動化する。

## ロード戦略
リソースは以下の区分に分けられる。  
  
|Name|Type|Scene|Description|
|-|-|-|-|
|埋め込み必須リソース|Builtin|Boot|起動シーンと紐づくリソース|
|埋め込みリソース|Resources|Boot|Resourcesから呼び出せるリソース **このプロジェクトでは使用しない**|
|永続必須リソース|Addressable|Core|AddressableかつBoot以外の全てのシーンにまたがって生存し、必ず読み込んでおく必要があるリソース|
|永続遅延リソース|Addressable|Core|AddressableかつBoot以外の全てのシーンにまたがって生存し、遅延して読み込めるリソース|
|ルートシーン必須リソース|Addressable|RootScene|AddressableかつRootScene内で生存し、必ず読み込んでおく必要があるリソース|
|サブシーン必須リソース|Addressable|SubScene|AddressableかつSubScene内で生存し、必ず読み込んでおく必要があるリソース|
|サブシーン遅延リソース|Addressable|SubScene|AddressableかつSubScene内で生存し、遅延して読み込める必要があるリソース|
|その他区分のあるリソース|Addressable|-|Addressableかつベース/サブシーン内で生存し、シーン管理外で読み込む必要のあるリソース|

シーン種別は [SceneSplitting](./SceneSplitting.md) を参照  
その他リソースではモデル + テクスチャ + 関連プレハブ 等のグループをラベル化する等が考えられる SmartAddresserと連携したいので、これも戦略を考えておきたい  
