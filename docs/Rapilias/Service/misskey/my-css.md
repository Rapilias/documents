```css
/* 角丸を抑止する */
*,
*::before,
*::after {
  --radius: 0px !important;
  border-radius: 0px !important;
}

/* カラムの右上のsvg */
.xj9v4 {
  display: none !important;
}

/* ウィジェット[プロフィール]のアイコン背景の白 */
.xtgyD {
  border: none !important;
}

/* 公開範囲がホームの投稿作成時の背景色を水色寄りに変更 */
.xpDI4.xxtDg._popup:has(.ti-home) {
  background-color: rgba(0, 40, 40, 1) !important;
}
/* 公開範囲がダイレクトの投稿作成時の背景色を黄色寄りに変更 */
.xpDI4.xxtDg._popup:has(.ti-mail) {
  background-color: rgba(40, 40, 10, 1) !important;
}
/* 公開範囲がフォロワー限定の投稿作成時の背景色を赤寄りに変更 */
.xpDI4.xxtDg._popup:has(.ti-lock) {
  background-color: rgba(40, 0, 40, 1) !important;
}

/* 閲覧注意画像が含まれるNoteを僅かにグレーする */
div.xcSej:has(.xt7Nj,.ti-alert-triangle) {
  background-color: rgb(246, 171, 178, 0.05) !important;
}

/* 時間を絶対時間で表記 */
time {
  font-size: 0;
}
time:after {
  content: attr(title);
  font-size: 0.76rem;
}
/* ノートの余白を減らす */
.x5yeR {
  padding: 12px 12px 12px 12px !important;
}
.xCPfz {
  margin-bottom: 4px !important;
}

/* 左Navbar の幅 */
.xryhL {
  --nav-width: 192px !important;
}

/* rss を1行に */
.ekmkgxbj > div > a[href*="https://trends.google/"] {
  display: inline;
}
```