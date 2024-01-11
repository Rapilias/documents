## 開発用特殊方針
### Events
ナビゲーションに関するイベントは`Select`で統一する。  `IPointer*`等は利用しない。  
ナビゲーション操作を行うコードにおいてはこの限りではない。  

### AsyncAnimation
原則`CancellationToken`を関連付け、フレーム単位の連打に耐えられるように作る。

