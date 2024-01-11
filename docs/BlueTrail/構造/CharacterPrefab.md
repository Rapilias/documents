## 概要

主にStudent/Enemyに関して適応するPrefabWorkflow `CharacterPrefabWorkflow.drawio`を参照。

## Avator / Scaling Configure

Avatorのセットアップが速いとScalingが正しくない状態が保持されてしまうので、`Animator`で`Weight > 1`っぽい見た目になったらここをやり直す

## TransformAnchor
キャラクター制御において何かしら意味を持つボーン。  
Humanoidでは表現できない一部のボーンを含めたHumanoidを良い感じに扱うための機構。  
これにより後続のいくつかのセットアップが自動化されたり、**キャラに特定の部位があるか**を一括検索/Validationを掛ける事ができるようになりセットアップの安定性が増す。  

## CollisionSetup
ランタイムでのみ利用される当たり判定。   
プレハブはGeneralから他の用途向けに派生する事を想定しており、敵対や操作可能といった重ための情報は単一の派生先で扱われるべき。  
Collisionは状況によって必要な物が大きく変わるためRuntimeに含めている。  