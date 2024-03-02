### チャンネルにリノート
https://misskey.io/notes/9byd9ossey

```js
/// @ 0.12.4
### {
  name: "チャンネルにリノート"
  version: "1.0"
  author: "BcS114"
  description: "選んだチャンネルにリノートします"
  permissions: ["write:notes","read:channels"]
  config: null
}

var channels = Mk:api("channels/followed" {})
each (let channel, channels) {
  let CHANNEL_ID = channel.id
  let CHANNEL_NAME = channel.name
  Plugin:register_note_action(`{CHANNEL_NAME}にリノート` @(note){
    Mk:api("notes/create" { channelId: CHANNEL_ID renoteId: note.id })
    Mk:dialog("" `{CHANNEL_NAME}にリノートしました`)
    note
  })
}
```