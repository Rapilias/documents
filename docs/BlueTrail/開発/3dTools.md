# 概要
各3DDCCツールで詰まったことや便利なことをメモる場所

# SubstanceDesigner
# SubstancePainter

# Blender 
+ Uvpackmaster 3
+ Voxel Heat Diffuse Skinning
+ Auto-Rig Pro
+ mmd_tools: https://github.com/UuuNyaa/blender_mmd_tools/releases

Zup -Yforawrd
## ループカットと平均では無く直線でやりたい
+ カットで左クリックを離さず`E`

## Unityに持ち込んだ際のAvatorのセットアップに失敗する
### 意図したボーンに関連付かない
+ `head`等、予約ボーン名と同一のメッシュが存在するとそちらと関連付けようとするので命名を調整する
  + UpperCamel+`Mesh`
## インポート時のボーンごとの向きが意図した向きと90度ズレる
+ Fbx Importのメニューで Armature/ボーン方向の自動整列

## アニメーション
+ 回転モードは単一のモードのみ有効なので、NLAトラックごとに回転モードを変更しない
  + 変換を掛けたい場合はRigfyを導入してポーズモード→ポーズ→`Convert Rotation Mode`
+ キーフレーム追加時はキー→キーフレームを挿入ではダメ 
  + ポーズモード→I→キーフレームの挿入メニューから

## Fbx Export
+ スケール1.0
+ スケールを適応 -> `全てFBX` **クソ大事** **これが無いと死ぬ**
+ トランスフォームの適応 **クソ大事**
