using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;


/// <summary>
/// Must contains IList for DevExpress
/// </summary>
public class csDataGridStringDataSource : ITypedList,IList
{
    private readonly List<List<string>> _source;
    private readonly List<string> _headers;

    public csDataGridStringDataSource(List<List<string>> source, List<string> headers)
    {
        _source = source ?? new List<List<string>>();
        _headers = headers ?? new List<string>();
    }

    // ITypedList 核心：告诉 Grid 有哪些列
    public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
    {
        var props = new PropertyDescriptor[_headers.Count];
        for (int i = 0; i < _headers.Count; i++)
        {
            // 将每一列映射到 List 的索引 i
            props[i] = new ListItemPropertyDescriptor(_headers[i], i);
        }
        return new PropertyDescriptorCollection(props);
    }

    public string GetListName(PropertyDescriptor[] listAccessors) => "";

    // IList 接口实现 (转发给原始 List)
    public object this[int index] { get => _source[index]; set => _source[index] = (List<string>)value; }
    public int Count => _source.Count;
    public bool IsReadOnly => false;
    public bool IsFixedSize => false;
    public object SyncRoot => null;
    public bool IsSynchronized => false;
    public int Add(object value) { _source.Add((List<string>)value); return _source.Count - 1; }
    public void Clear() => _source.Clear();
    public bool Contains(object value) => _source.Contains((List<string>)value);
    public int IndexOf(object value) => _source.IndexOf((List<string>)value);
    public void Insert(int index, object value) => _source.Insert(index, (List<string>)value);
    public void Remove(object value) => _source.Remove((List<string>)value);
    public void RemoveAt(int index) => _source.RemoveAt(index);
    public void CopyTo(Array array, int index) => ((ICollection)_source).CopyTo(array, index);
    public IEnumerator GetEnumerator() => _source.GetEnumerator();
}

// 属性描述符：定义如何读写 List<string> 中的特定位置
public class ListItemPropertyDescriptor : PropertyDescriptor
{
    private readonly int _index;
    public ListItemPropertyDescriptor(string name, int index) : base(name, null) => _index = index;

    public override Type ComponentType => typeof(List<string>);
    public override Type PropertyType => typeof(string);
    public override bool IsReadOnly => false;
    public override object GetValue(object component) 
    {
        var row = (List<string>)component;
        return _index < row.Count ? row[_index] : null;
    }
    public override void SetValue(object component, object value) 
    {
        var row = (List<string>)component;
        while (row.Count <= _index) row.Add(""); // 防止越界
        row[_index] = value?.ToString();
    }
    public override bool CanResetValue(object component) => false;
    public override void ResetValue(object component) { }
    public override bool ShouldSerializeValue(object component) => false;
}