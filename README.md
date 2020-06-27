# ReviewCollection
复习集合

### SRP 自定义渲染管线

- 多摄像机时：mul_cam_test
 1 一个ClearFlag设置为SkyBox或Color Only（首先渲染的那个，渲染大部分物体，除了UI）,一个设置为Depth（后渲染的那个，只渲染ui）
 2 也可以为每个相机单写一个渲染模式。
